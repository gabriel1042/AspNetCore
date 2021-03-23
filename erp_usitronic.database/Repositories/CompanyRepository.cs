using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace erp_usitronic.database.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApiDbContext context) : base(context) { }
    }
}
