using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IBankService : IDisposable
    {
        Task<List<Bank>> GetAll();
        Task<Bank> GetById(int id);
        Task<bool> Update(Bank user);
        Task<bool> Create(Bank user);
        Task<bool> Delete(int id);
        bool Exists(int id);

        bool UpdateBalance(Bank bank);

    }
}
