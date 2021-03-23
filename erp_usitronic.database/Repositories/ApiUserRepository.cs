using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace erp_usitronic.database.Repositories
{
    public class ApiUserRepository : Repository<ApiUser>, IApiUserRepository
    {
        public ApiUserRepository(ApiDbContext context) : base(context) { }

        public bool IsAuthorized(string userName, string resource, string method)
        {
            var user = from u in Db.ApiUsers
                       join p in Db.Permissions on u.Id equals p.ApiUserId
                       where u.Name == userName && p.Authorized == true && p.Resource == resource && p.Method == method
                       select u;
                       
            return user.ToList().Count>0;
        }
    }
}
