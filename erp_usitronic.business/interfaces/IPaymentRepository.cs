using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.business.interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        bool UpdatePaidStatus(Payment payment);
    }
}
