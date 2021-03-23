using erp_usitronic.business.models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IApiUserRepository : IRepository<ApiUser>
    {
        bool IsAuthorized(string userName, string resource, string method);
    }
}
