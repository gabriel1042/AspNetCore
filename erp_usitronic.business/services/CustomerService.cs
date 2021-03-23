using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.business.models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPersonService _personService;

        public CustomerService(ICustomerRepository customerRepository,
                               IPersonService personService,
                                 INotificator notificator) : base(notificator)
        {
            _customerRepository = customerRepository;
            _personService = personService;
        }

        public async Task<bool> Create(Customer customer)
        {
            if (!ExecuteValidation(new CustomerValidation(), customer)) return false;
            if (!DependeciesIsValid(customer)) return false;

            await _customerRepository.Add(customer);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _customerRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }

        public bool Exists(int id)
        {
            return _customerRepository.Any(e => e.Id == id);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task<bool> Update(Customer customer)
        {
            if (!ExecuteValidation(new CustomerValidation(), customer)) return false;
            if (!DependeciesIsValid(customer)) return false;

            await _customerRepository.Update(customer);
            return true;
        }

        private bool DependeciesIsValid(Customer customer)
        {
            if (!_personService.Exists(customer.PersonId))
            {
                Notify("Não existe uma pessoa com o id informado na propriedade PersonId");
                return false;
            }
            return true;
        }
    }
}
