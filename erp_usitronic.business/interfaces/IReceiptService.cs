using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IReceiptService : IDisposable
    {
        Task<List<Receipt>> GetAll();
        Task<Receipt> GetById(int id);
        Task<bool> Update(Receipt user);
        Task<bool> UpdatePaidStatus(Receipt receipt);
        Task<bool> Create(Receipt user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
