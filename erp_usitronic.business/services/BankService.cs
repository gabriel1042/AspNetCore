using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class BankService : BaseService, IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository,
                                 INotificator notificator) : base(notificator)
        {
            _bankRepository = bankRepository;
        }

        public async Task<bool> Create(Bank bank)
        {
            if (!ExecuteValidation(new BankValidation(), bank)) return false;

            await _bankRepository.Add(bank);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _bankRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _bankRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _bankRepository.Any(e => e.Id == id);
        }

        public async Task<List<Bank>> GetAll()
        {
            return await _bankRepository.GetAll();
        }

        public async Task<Bank> GetById(int id)
        {
            return await _bankRepository.GetById(id);
        }

        public async Task<bool> Update(Bank bank)
        {
            if (!ExecuteValidation(new BankValidation(), bank)) return false;
            await _bankRepository.Update(bank);
            return true;
        }
        public bool UpdateBalance(Bank bank)
        {
            return _bankRepository.UpdateBalance(bank);
        }
    }
}
