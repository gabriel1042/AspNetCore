using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;

namespace erp_usitronic.business.services
{
    public class FinancialMovementService : BaseService, IFinancialMovementService
    {
        private readonly IFinancialMovementRepository _financialMovementRepository;
        private readonly IBankService _bankService;
        private readonly IReceiptRepository _receiptRepository;
        private readonly IPaymentRepository _paymentRepository;


        public FinancialMovementService(IFinancialMovementRepository financialMovementRepository,
                                        IBankService bankService,
                                        IReceiptRepository receiptRepository,
                                        IPaymentRepository paymentRepository,
                                        INotificator notificator) : base(notificator)
        {
            _financialMovementRepository = financialMovementRepository;
            _bankService = bankService;
            _receiptRepository = receiptRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> BuildAndCreateAsync(Payment paymentPaid)
        {
            var payment = await _paymentRepository.GetByIdAsNoTracking(paymentPaid.Id);
            var bank = await _bankService.GetById(payment.BankId);
            var afterBalance = !payment.Paid ? bank.Balance - payment.PaymentValue : bank.Balance + payment.PaymentValue;
            var financialMovement = new FinancialMovement
            {
                Bank = bank,
                BankId = bank.Id,
                PreviousBalance = bank.Balance,
                TransactionDate = DateTime.Now,
                TransactionValue = payment.PaymentValue,
                AfterBalance = afterBalance,
                Kind = 'S'
            };
            bank.Balance = afterBalance;
            _bankService.UpdateBalance(bank);
            return await Create(financialMovement);
        }

        public async Task<bool> BuildAndCreate(Receipt receiptPaid)
        {
            var receipt = await _receiptRepository.GetByIdAsNoTracking(receiptPaid.Id);
            var bank = await _bankService.GetById(receipt.BankId);
            var afterBalance = !receipt.Paid ? bank.Balance + receipt.ReceiptValue : bank.Balance - receipt.ReceiptValue;
            var financialMovement = new FinancialMovement
            {
                Bank = bank,
                BankId = bank.Id,
                PreviousBalance = bank.Balance,
                TransactionDate = DateTime.Now,
                TransactionValue = receipt.ReceiptValue,
                AfterBalance = afterBalance,
                Kind = 'E'
            };
            bank.Balance = afterBalance;
            _bankService.UpdateBalance(bank);
            return await Create(financialMovement);
        }

        public async Task<bool> Create(FinancialMovement financialMovement)
        {
            if (!ExecuteValidation(new FinancialMovementValidation(), financialMovement)) return false;
            if (!DependeciesIsValid(financialMovement)) return false;

            await _financialMovementRepository.Add(financialMovement);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _financialMovementRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _financialMovementRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _financialMovementRepository.Any(e => e.Id == id);
        }

        public async Task<List<FinancialMovement>> GetAll()
        {
            return await _financialMovementRepository.GetAll();
        }

        public async Task<FinancialMovement> GetById(int id)
        {
            return await _financialMovementRepository.GetById(id);
        }

        public async Task<bool> Update(FinancialMovement financialMovement)
        {
            if (!ExecuteValidation(new FinancialMovementValidation(), financialMovement)) return false;
            if (!DependeciesIsValid(financialMovement)) return false;

            await _financialMovementRepository.Update(financialMovement);
            return true;
        }

        private bool DependeciesIsValid(FinancialMovement financialMovement)
        {
            if (!_bankService.Exists(financialMovement.BankId))
            {
                Notify("Não existe um banco com o id informado na propriedade BankId");
                return false;
            }
            return true;
        }
    }
}
