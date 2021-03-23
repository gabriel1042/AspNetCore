using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IAddressService : IDisposable
    {
        Task<List<Address>> GetAll();
        Task<Address> GetById(int id);
        Task<bool> Update(Address user);
        Task<bool> Create(Address user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
