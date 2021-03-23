using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface ICheckService : IDisposable
    {
        Task<List<Check>> GetAll();
        Task<Check> GetById(int id);
        Task<bool> Update(Check user);
        Task<bool> Create(Check user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
