using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICompanyService _companyService;
        private readonly ISupplierService _supplierService;
        private readonly IFinancialMovementService _financialMovementService;

        public PaymentService(IPaymentRepository paymentRepository,
                              ICompanyService companyService,
                              ISupplierService supplierService,
                              IFinancialMovementService financialMovementService,
                                 INotificator notificator) : base(notificator)
        {
            _paymentRepository = paymentRepository;
            _supplierService = supplierService;
            _companyService = companyService;
            _financialMovementService = financialMovementService;
        }

        public async Task<bool> Create(Payment payment)
        {
            if (!ExecuteValidation(new PaymentValidation(), payment)) return false;
            if (!DependeciesIsValid(payment)) return false;

            await _paymentRepository.Add(payment);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _paymentRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _paymentRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _paymentRepository.Any(e => e.Id == id);
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _paymentRepository.GetAll();
        }

        public async Task<Payment> GetById(int id)
        {
            return await _paymentRepository.GetById(id);
        }

        public async Task<bool> Update(Payment payment)
        {
            if (!ExecuteValidation(new PaymentValidation(), payment)) return false;
            if (!DependeciesIsValid(payment)) return false;
            if (!await AllowUpdateAsync(payment)) return false;

            await _paymentRepository.Update(payment);
            return true;
        }

        public async Task<bool> UpdatePaidStatus(Payment payment)
        {
            if (!await AllowsChangePaymentStatusAsync(payment)) return false;
            await _financialMovementService.BuildAndCreateAsync(payment);
            return _paymentRepository.UpdatePaidStatus(payment);
        }


        private async Task<bool> AllowUpdateAsync(Payment payment)
        {
            var paymentToValidate = await _paymentRepository.GetByIdAsNoTracking(payment.Id);
            if (paymentToValidate.Paid)
            {
                Notify("Não é possível editar um pagamento baixado.");
                return false;
            }

            return true;
        }

        private async Task<bool> AllowsChangePaymentStatusAsync(Payment payment)
        {
            var paymentToChange = await _paymentRepository.GetByIdAsNoTracking(payment.Id);
            if (paymentToChange == null)
            {
                Notify("O pagamento informado não existe.");
                return false;
            }
            if (payment.Paid && paymentToChange.Paid)
            {
                Notify("O pagamento informado já está baixado.");
                return false;
            }

            if (payment.Paid == false && paymentToChange.Paid == false)
            {
                Notify("Não é possível cancelar a baixa de um pagamento que não está baixado.");
                return false;
            }
            return true;
        }

        private bool DependeciesIsValid(Payment payment)
        {
            if (!_companyService.Exists(payment.CompanyId))
            {
                Notify("Não existe uma empresa com o id informado na propriedade CompanyId");
                return false;
            }

            if (!_supplierService.Exists(payment.SupplierId))
            {
                Notify("Não existe um fornecedor com o id informado na propriedade SupplierId");
                return false;
            }
            return true;
        }
    }
}
