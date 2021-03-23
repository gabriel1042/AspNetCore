using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;

namespace erp_usitronic.business.services
{
    public class CashFlowService : BaseService, ICashFlowService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IReceiptRepository _receiptRepository;
        private readonly IBankRepository _bankRepository;
        public CashFlowService(INotificator notificador,
                                    IPaymentRepository paymentRepository,
                                    IReceiptRepository receiptRepository,
                                    IBankRepository bankRepository) : base(notificador)
        {
            _paymentRepository = paymentRepository;
            _receiptRepository = receiptRepository;
            _bankRepository = bankRepository;
        }

        public async Task<CashFlow> GetByRangeAsync(DateTime startDate, DateTime endDate, int companyId)
        {
            List<CashFlowDay> cashFlowDays = new List<CashFlowDay>();

            var payments = await _paymentRepository.FindAsNoTracking(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate && p.CompanyId == companyId);
            payments = payments.OrderBy(x => x.PaymentDate).ToList();
            var receipts = await _receiptRepository.FindAsNoTracking(p => p.ReceiptDate >= startDate && p.ReceiptDate <= endDate && p.CompanyId == companyId);
            await AddBankBalance(companyId, payments, receipts);
            receipts = receipts.OrderBy(x => x.ReceiptDate).ToList();

            var cashFlow = GeneratePaymentFlow(payments.GroupBy(x => x.PaymentDate).ToList(), receipts);
            return cashFlow;
        }

        private async Task AddBankBalance(int companyId, List<Payment> payments, List<Receipt> receipts)
        {
            var banks = await _bankRepository.FindAsNoTracking(x => x.EntersCashFlow == true);
            if (banks.Count > 0)
            {
                if (payments.Where(x => x.PaymentDate <= DateTime.Now).ToList().Count > 0)
                {
                    foreach (var bank in banks)
                    {
                        var receipt = new Receipt()
                        {
                            ReceiptDate = DateTime.Now,
                            CompanyId = companyId,
                            ReceiptValue = bank.Balance,
                            Description = $"Caixa Interno - {bank.Name}",
                        };
                        receipts.Add(receipt);
                    }

                }
            }
        }

        private CashFlow GeneratePaymentFlow(IEnumerable<IGrouping<DateTime?, Payment>> groupedPayments,
                                        List<Receipt> receipts)
        {
            var cashFlow = new CashFlow();
            CashFlowDay lastCashFlowDay = null;

            foreach (var payments in groupedPayments)
            {
                var cashFlowDay = new CashFlowDay();
                var lastDayBalance = lastCashFlowDay == null ? 0 : lastCashFlowDay.DayBalace;
                var lastCashDateFlow = lastCashFlowDay == null ? DateTime.MinValue : lastCashFlowDay.Date.Value;

                cashFlowDay.DayBalace = (-1 * payments.Sum(x => x.PaymentValue)) + lastDayBalance;
                cashFlowDay.Date = payments.Key;
                AdjustWorkingDays(payments, cashFlowDay);
                cashFlowDay.Payments.AddRange(payments);

                var filteredReceipts = receipts.Where(x => x.ReceiptDate > lastCashDateFlow && x.ReceiptDate <= cashFlowDay.Date);
                cashFlowDay.DayBalace += filteredReceipts.Sum(x => x.ReceiptValue);
                cashFlowDay.Receipts.AddRange(filteredReceipts);

                cashFlow.CashFlowDays.Add(cashFlowDay);
                lastCashFlowDay = cashFlowDay;
            }
            return cashFlow;
        }

        private static void AdjustWorkingDays(IGrouping<DateTime?, Payment> payments,
                                                CashFlowDay cashFlowDay)
        {
            if (cashFlowDay.Date.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                cashFlowDay.Date = cashFlowDay.Date.Value.AddDays(2);
                payments.ToList().ForEach(x => x.PaymentDate = x.PaymentDate.Value.AddDays(2));
            }
            else if (cashFlowDay.Date.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                cashFlowDay.Date = cashFlowDay.Date.Value.AddDays(1);
                payments.ToList().ForEach(x => x.PaymentDate = x.PaymentDate.Value.AddDays(1));
            }
        }

    }
}
