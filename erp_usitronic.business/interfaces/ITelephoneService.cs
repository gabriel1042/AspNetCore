using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface ITelephoneService : IDisposable
    {
        Task<List<Telephone>> GetAll();
        Task<Telephone> GetById(int id);
        Task<bool> Update(Telephone user);
        Task<bool> Create(Telephone user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
