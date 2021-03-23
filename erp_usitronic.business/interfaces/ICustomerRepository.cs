using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task RemoveByPersonId(int personId);
    }
}
