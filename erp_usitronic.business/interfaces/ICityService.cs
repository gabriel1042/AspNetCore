using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface ICityService : IDisposable
    {
        Task<List<City>> GetAll();
        Task<City> GetById(int id);
        Task<bool> Update(City user);
        Task<bool> Create(City user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
