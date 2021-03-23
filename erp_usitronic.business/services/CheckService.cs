using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class CheckService : BaseService, ICheckService
    {
        private readonly ICheckRepository _checkRepository;
        private readonly IBankService _bankService;
        private readonly IPaymentService _paymentService;

        public CheckService(ICheckRepository checkRepository,
                            IBankService bankService,
                            IPaymentService paymentService,
                            INotificator notificator) : base(notificator)
        {
            _checkRepository = checkRepository;
            _bankService = bankService;
            _paymentService = paymentService;
        }

        public async Task<bool> Create(Check check)
        {
            if (!ExecuteValidation(new CheckValidation(), check)) return false;
            if (!DependenciesIsValid(check)) return false;

            await _checkRepository.Add(check);
            return true;
        }

        private bool DependenciesIsValid(Check check)
        {
            if (!_bankService.Exists(check.BankId))
            {
                Notify("Não existe um banco com o id informado na propriedade BankId");
                return false;
            }
            if (!_paymentService.Exists(check.PaymentId))
            {
                Notify("Não existe um pagamento com o id informado na propriedade PaymentId");
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _checkRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _checkRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _checkRepository.Any(e => e.Id == id);
        }

        public async Task<List<Check>> GetAll()
        {
            return await _checkRepository.GetAll();
        }

        public async Task<Check> GetById(int id)
        {
            return await _checkRepository.GetById(id);
        }

        public async Task<bool> Update(Check check)
        {
            if (!ExecuteValidation(new CheckValidation(), check)) return false;
            await _checkRepository.Update(check);
            return true;
        }
    }
}
