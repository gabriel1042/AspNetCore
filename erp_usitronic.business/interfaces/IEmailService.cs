using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IEmailService : IDisposable
    {
        Task<List<Email>> GetAll();
        Task<Email> GetById(int id);
        Task<bool> Update(Email user);
        Task<bool> Create(Email user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
