using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.models;

namespace erp_usitronic.business.interfaces
{
    public interface IFinancialMovementService : IDisposable
    {
        Task<List<FinancialMovement>> GetAll();
        Task<FinancialMovement> GetById(int id);
        Task<bool> Update(FinancialMovement financialMovement);
        Task<bool> Create(FinancialMovement financialMovement);
        Task<bool> Delete(int id);
        bool Exists(int id);
        Task<bool> BuildAndCreateAsync(Payment payment);
        Task<bool> BuildAndCreate(Receipt receipt);
    }
}
