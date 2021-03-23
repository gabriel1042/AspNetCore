using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IStateService : IDisposable
    {
        Task<List<State>> GetAll();
        Task<State> GetById(int id);
        Task<bool> Update(State user);
        Task<bool> Create(State user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
