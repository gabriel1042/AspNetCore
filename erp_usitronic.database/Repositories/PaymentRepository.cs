using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.database.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApiDbContext context) : base(context) { }

        public override async Task Update(Payment payment)
        {
            DbSet.Update(payment);
            Db.Entry(payment).Property(x => x.Paid).IsModified = false;
            await SaveChanges();
        }

        public bool UpdatePaidStatus(Payment payment)
        {
            Db.Payments.Attach(payment).Property(x => x.Paid).IsModified = true;
            Db.SaveChanges();
            return true;
        }
    }
}
