using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IPersonService : IDisposable
    {
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<bool> Update(Person person);
        Task<bool> Create(Person person);
        Task<bool> Delete(int id);
        Task<bool> Delete(Person person);
        bool Exists(int id);
    }
}
