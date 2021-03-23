using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<bool> Update(Customer user);
        Task<bool> Create(Customer user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
