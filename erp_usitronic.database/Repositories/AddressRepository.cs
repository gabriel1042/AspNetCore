using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.database.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApiDbContext context) : base(context) { }

        public async Task RemoveByPersonId(int personId)
        {
            var entity = await Find(x => x.PersonId == personId);
            DbSet.RemoveRange(entity);
        }
    }
}