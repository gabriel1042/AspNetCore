using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface ICompanyService : IDisposable
    {
        Task<List<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<bool> Update(Company user);
        Task<bool> Create(Company user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
