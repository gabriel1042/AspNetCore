using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using erp_usitronic.Database;

namespace erp_usitronic.database.Repositories
{
    public class FinancialMovementRepository : Repository<FinancialMovement>, IFinancialMovementRepository
    {
        public FinancialMovementRepository(ApiDbContext context) : base(context) { }

        public override async Task<FinancialMovement> Add(FinancialMovement financialMovement)
        {
            await DbSet.AddAsync(financialMovement);
            return financialMovement;
        }
    }
}
