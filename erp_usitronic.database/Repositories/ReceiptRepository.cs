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
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ApiDbContext context) : base(context) { }

        public override async Task Update(Receipt receipt)
        {
            DbSet.Update(receipt);
            Db.Entry(receipt).Property(x => x.Paid).IsModified = false;
            await SaveChanges();
        }

        public bool UpdatePaidStatus(Receipt receipt)
        {
            Db.Receipts.Attach(receipt).Property(x => x.Paid).IsModified = true;
            Db.SaveChanges();
            return true;
        }
    }
}
