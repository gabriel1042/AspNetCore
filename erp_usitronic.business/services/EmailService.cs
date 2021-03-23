using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class EmailService : BaseService, IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IPersonService _personService;

        public EmailService(IEmailRepository emailRepository,
                            IPersonService personService,
                                 INotificator notificator) : base(notificator)
        {
            _emailRepository = emailRepository;
            _personService = personService;
        }

        public async Task<bool> Create(Email email)
        {
            if (!ExecuteValidation(new EmailValidation(), email)) return false;
            if (!DependeciesIsValid(email)) return false;

            await _emailRepository.Add(email);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _emailRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _emailRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _emailRepository.Any(e => e.Id == id);
        }

        public async Task<List<Email>> GetAll()
        {
            return await _emailRepository.GetAll();
        }

        public async Task<Email> GetById(int id)
        {
            return await _emailRepository.GetById(id);
        }

        public async Task<bool> Update(Email email)
        {
            if (!ExecuteValidation(new EmailValidation(), email)) return false;
            if (!DependeciesIsValid(email)) return false;

            await _emailRepository.Update(email);
            return true;
        }

        private bool DependeciesIsValid(Email email)
        {
            if (!_personService.Exists(email.PersonId))
            {
                Notify("Não existe uma pessoa com o id informado na propriedade PersonId");
                return false;
            }
            return true;
        }
    }
}
