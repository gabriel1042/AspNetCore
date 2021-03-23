using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IPaymentService : IDisposable
    {
        Task<List<Payment>> GetAll();
        Task<Payment> GetById(int id);
        Task<bool> Update(Payment user);
        Task<bool> UpdatePaidStatus(Payment payment);
        Task<bool> Create(Payment user);
        Task<bool> Delete(int id);
        bool Exists(int id);
    }
}
