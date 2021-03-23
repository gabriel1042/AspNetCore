using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApiDbContext context) : base(context) { }
    }
}
