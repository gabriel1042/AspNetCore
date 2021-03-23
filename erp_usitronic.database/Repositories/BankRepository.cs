using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.database.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(ApiDbContext context) : base(context) { }

        public bool UpdateBalance(Bank bank)
        {
            DbSet.Update(bank);
            return true;
        }
    }
}
