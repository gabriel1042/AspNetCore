using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.api.Configuration;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.client.HttpResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace erp_usitronic.tests
{
    [TestClass]
    public class DataAccessTest
    {
        private IPersonService _personService;
        private ICustomerService _customerService;

        [TestInitialize]
        public void Setup()
        {
            _personService = DependecyInjectionConfig.GetService<IPersonService>();
            _customerService = DependecyInjectionConfig.GetService<ICustomerService>();
        }

        [TestMethod]
        public async Task DataBaseConcurrentAccessTestAsync()
        {
            var person = await _personService.GetById(1);
            for (int i = 0; i < 10; i++)
                await _personService.Update(person);

            var newPerson = new Person
            {
                Name = "Pessoa Nova",
                KindPerson = 'J',
                IdNumber = "24614617000165",
                Customers = new List<Customer>
                {
                    new Customer
                    {
                        CompanyName = "Cliente Novo",
                        StateRegistration = "12345678"
                    }
                }
            };
            
            await _personService.Create(newPerson);

            for (int i = 0; i < 10; i++)
                await _personService.Update(newPerson);

            newPerson = await _personService.GetById(31);
            //await _customerService.Delete(newPerson.Customer.Id);
            //newPerson.Customer = null;
            var deleted = await _personService.Delete(newPerson.Id);

            var deletedPerson = await _personService.GetById(newPerson.Id);
        }

        [TestMethod]
        public async Task ApiConcurrentAccessTestAsync()
        {
            var person = await _personService.GetById(1);
            for (int i = 0; i < 10; i++)
                await _personService.Update(person);

            var newPerson = new Person
            {
                Name = "Pessoa Nova",
                KindPerson = 'J',
                IdNumber = "24614617000165",
                Customers = new List<Customer>
                {
                    new Customer
                    {
                        CompanyName = "Cliente Novo",
                        StateRegistration = "12345678"
                    }                    
                }
            };

            await _personService.Create(newPerson);

            for (int i = 0; i < 10; i++)
                await _personService.Update(newPerson);

            newPerson = await _personService.GetById(15);
            await _customerService.Delete(newPerson.Customers.First().Id);
            newPerson.Customers = null;
            var deleted = await _personService.Delete(newPerson.Id);

            var deletedPerson = await _personService.GetById(newPerson.Id);
        }
    }
}
