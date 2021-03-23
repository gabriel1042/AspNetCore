using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.database.Repositories
{
    public class ApiTokenRepository : Repository<ApiToken>, IApiTokenRepository
    {
        public ApiTokenRepository(ApiDbContext context) : base(context) { }

        public async Task RemoveMany(Expression<Func<ApiToken, bool>> predicate)
        {
            var users = await FindAsNoTracking(predicate);
            if (users == null) return;

            if (users.Count > 0)
            {
                DbSet.RemoveRange(users);
                await SaveChanges();
            }
                
        }
    }
}
