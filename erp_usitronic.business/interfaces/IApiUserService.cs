using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.business.interfaces
{
    public interface IApiUserService
    {
        bool IsAuthorized(string userName, string resource, string method);
    }
}
