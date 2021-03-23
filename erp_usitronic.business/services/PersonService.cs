using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace erp_usitronic.business.services
{
    public class PersonService : BaseService, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITelephoneRepository _telephoneRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICustomerRepository _customerRepository;

        public PersonService(IPersonRepository personRepository,
                             ITelephoneRepository telephoneRepository,
                             IEmailRepository emailRepository,
                             IAddressRepository addressRepository, 
                             ISupplierRepository supplierRepository,
                             ICustomerRepository customerRepository,
                             INotificator notificator) : base(notificator)
        {
            _personRepository = personRepository;
            _telephoneRepository = telephoneRepository;
            _emailRepository = emailRepository;
            _addressRepository = addressRepository;
            _supplierRepository = supplierRepository;
            _customerRepository = customerRepository;
        }

        public async Task<bool> Create(Person person)
        {
            if (!ExecuteValidation(new PersonValidation(), person)) return false;
            if (!IsValidComplements(person)) return false;

            await _personRepository.Add(person);
        
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _emailRepository.RemoveByPersonId(id);
                await _addressRepository.RemoveByPersonId(id);
                await _telephoneRepository.RemoveByPersonId(id);
                await _customerRepository.RemoveByPersonId(id);
                await _supplierRepository.RemoveByPersonId(id);
                await _personRepository.Remove(id);
            }
            catch (DbUpdateException dbEx)
            {
                if(dbEx.InnerException.HResult == -2146232060)
                {
                    string message = "Não é possível excluir a pessoa, pois, existem relacionamentos entre esta entidade e outros registros do sistema.";
                    message += $"\n\nMensagem técnica: {dbEx.InnerException.Message}";
                    Notify(message);
                }
            }
            
            return true;
        }

        public async Task<bool> Delete(Person person)
        {
            try
            {

                await _personRepository.Remove(person);
            }
            catch (DbUpdateException dbEx)
            {
                if (dbEx.InnerException.HResult == -2146232060)
                {
                    string message = "Não é possível excluir a pessoa, pois, existem relacionamentos entre esta entidade e outros registros do sistema.";
                    message += $"\n\nMensagem técnica: {dbEx.InnerException.Message}";
                    Notify(message);
                }
            }

            return true;
        }

        public void Dispose()
        {
            _personRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _personRepository.Any(e => e.Id == id);
        }

        public async Task<List<Person>> GetAll()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person> GetById(int id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task<bool> Update(Person person)
        {
            try
            {
                if (!ExecuteValidation(new PersonValidation(), person)) return false;
                if (!IsValidComplements(person)) return false;

                RemoveComplementsIfIsNull(person);
                await _personRepository.Update(person);
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                if (dbEx.InnerException.HResult == -2146232060)
                {
                    string message = "Não é possível editar a pessoa, pois, existem relacionamentos entre esta entidade e outros registros do sistema.";
                    message += $"\n\nMensagem técnica: {dbEx.InnerException.Message}";
                    Notify(message);
                }
                return false;
            }            
        }

        private void RemoveComplementsIfIsNull(Person person)
        {
            if (person.Telephones == null || person.Telephones.Count == 0)
            {
                _telephoneRepository.RemoveByPersonId(person.Id);
            }

            if (person.Emails == null || person.Emails.Count == 0)
            {
                _emailRepository.RemoveByPersonId(person.Id);
            }

            if (person.Adresses == null || person.Adresses.Count == 0)
            {
                _addressRepository.RemoveByPersonId(person.Id);
            }

            if (person.Customers == null)
            {
                _customerRepository.RemoveByPersonId(person.Id);
            }

            if (person.Supplier == null)
            {
                _supplierRepository.RemoveByPersonId(person.Id);
            }
        }

        private bool IsValidComplements(Person person)
        {
            if (person.Telephones != null)
            {
                foreach (var telephone in person.Telephones)
                {
                    if (!ExecuteValidation(new TelephoneValidation(), telephone)) return false;
                }
            }

            if (person.Emails != null)
            {
                foreach (var email in person.Emails)
                {
                    if (!ExecuteValidation(new EmailValidation(), email)) return false;
                }
            }

            if (person.Adresses != null)
            {
                foreach (var address in person.Adresses)
                {
                    if (!ExecuteValidation(new AddressValidation(), address)) return false;
                }
            }

            if(person.Customers == null && person.Supplier == null)
            {
                Notify("É necessário que uma pessoa seja cliente ou fornecedor.");
                return false;
            }

            if (person.Customers != null)
            {
                if (!ExecuteValidation(new CustomerValidation(), person.Customers.First())) return false;
            }

            if (person.Supplier != null)
            {
                if (!ExecuteValidation(new SupplierValidation(), person.Supplier)) return false;
            }

            return true;
        }
    }
}
