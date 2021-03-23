using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.models;

namespace erp_usitronic.business.interfaces
{
    public interface ICashFlowService 
    {
        Task<CashFlow> GetByRangeAsync(DateTime startDate, DateTime endDate, int companyId);
    }
}