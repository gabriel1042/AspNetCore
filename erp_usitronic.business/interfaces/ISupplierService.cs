using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface ISupplierService : IDisposable
    {
        Task<List<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task<bool> Update(Supplier user);
        Task<bool> Create(Supplier user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
