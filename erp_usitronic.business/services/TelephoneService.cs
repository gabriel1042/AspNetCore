using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class TelephoneService : BaseService, ITelephoneService
    {
        private readonly ITelephoneRepository _telephoneRepository;
        private readonly IPersonService _personService;
        public TelephoneService(ITelephoneRepository telephoneRepository,
                                IPersonService personService,
                                 INotificator notificator) : base(notificator)
        {
            _telephoneRepository = telephoneRepository;
            _personService = personService;
        }

        public async Task<bool> Create(Telephone telephone)
        {
            if (!ExecuteValidation(new TelephoneValidation(), telephone)) return false;
            if (!DependeciesIsValid(telephone)) return false;

            await _telephoneRepository.Add(telephone);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _telephoneRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _telephoneRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _telephoneRepository.Any(e => e.Id == id);
        }

        public async Task<List<Telephone>> GetAll()
        {
            return await _telephoneRepository.GetAll();
        }

        public async Task<Telephone> GetById(int id)
        {
            return await _telephoneRepository.GetById(id);
        }

        public async Task<bool> Update(Telephone telephone)
        {
            if (!ExecuteValidation(new TelephoneValidation(), telephone)) return false;
            if (!DependeciesIsValid(telephone)) return false;

            await _telephoneRepository.Update(telephone);
            return true;
        }

        private bool DependeciesIsValid(Telephone telephone)
        {
            if (!_personService.Exists(telephone.PersonId))
            {
                Notify("Não existe uma pessoa com o id informado na propriedade PersonId");
                return false;
            }
            return true;
        }
    }
}
