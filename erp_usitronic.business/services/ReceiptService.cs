using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class ReceiptService : BaseService, IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly ICompanyService _companyService;
        private readonly ICustomerService _customerService;
        private readonly IFinancialMovementService _financialMovementService;

        public ReceiptService(IReceiptRepository receiptRepository,
                              ICompanyService companyService,
                              ICustomerService customerService,
                              IFinancialMovementService financialMovementService,
                                 INotificator notificator) : base(notificator)
        {
            _receiptRepository = receiptRepository;
            _customerService = customerService;
            _companyService = companyService;
            _financialMovementService = financialMovementService;
        }

        public async Task<bool> Create(Receipt receipt)
        {
            if (!ExecuteValidation(new ReceiptValidation(), receipt)) return false;
            if (!DependeciesIsValid(receipt)) return false;

            await _receiptRepository.Add(receipt);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _receiptRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _receiptRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _receiptRepository.Any(e => e.Id == id);
        }

        public async Task<List<Receipt>> GetAll()
        {
            return await _receiptRepository.GetAll();
        }

        public async Task<Receipt> GetById(int id)
        {
            return await _receiptRepository.GetById(id);
        }

        public async Task<bool> Update(Receipt receipt)
        {
            if (!ExecuteValidation(new ReceiptValidation(), receipt)) return false;
            if (!DependeciesIsValid(receipt)) return false;
            if (!await AllowUpdate(receipt)) return false;

            await _receiptRepository.Update(receipt);
            return true;
        }

        public async Task<bool> UpdatePaidStatus(Receipt receipt)
        {
            if (!await AllowsChangePaymentStatusAsync(receipt)) return false;
            if (await _financialMovementService.BuildAndCreate(receipt))
                return _receiptRepository.UpdatePaidStatus(receipt);
            else
                return false;
        }

        private async Task<bool> AllowUpdate(Receipt receipt)
        {
            var receiptToValidate = await _receiptRepository.GetByIdAsNoTracking(receipt.Id);
            if (receiptToValidate.Paid)
            {
                Notify("Não é possível editar um recebimento baixado.");
                return false;
            }

            return true;
            
        }

        private async Task<bool> AllowsChangePaymentStatusAsync(Receipt receipt)
        {
            var receiptToChange = await _receiptRepository.GetByIdAsNoTracking(receipt.Id);
            
            if (receiptToChange == null)
            {
                Notify("O recebimento informado não existe.");
                return false;
            }
            if (receipt.Paid && receiptToChange.Paid)
            {
                Notify("O recebimento informado já está baixado.");
                return false;
            }

            if (receipt.Paid==false && receiptToChange.Paid==false)
            {
                Notify("Não é possível cancelar a baixa de um recebimento que não está baixado.");
                return false;
            }
            return true;
        }

        private bool DependeciesIsValid(Receipt receipt)
        {
            if (!_companyService.Exists(receipt.CompanyId))
            {
                Notify("Não existe uma empresa com o id informado na propriedade CompanyId");
                return false;
            }

            if (!_customerService.Exists(receipt.CustomerId))
            {
                Notify("Não existe um cliente com o id informado na propriedade CustomerId");
                return false;
            }
            return true;
        }
    }
}
