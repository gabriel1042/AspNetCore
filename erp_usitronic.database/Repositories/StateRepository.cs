using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.database.Repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(ApiDbContext context) : base(context) { }

        public override async Task<State> GetById(int id)
        {
            return await DbSet.Include(s => s.Cities)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
