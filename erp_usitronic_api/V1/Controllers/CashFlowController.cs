using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erp_usitronic.api.Controllers;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp_usitronic.api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CashFlowController : MainController
    {
        private readonly ICashFlowService _cashFlowService;

        public CashFlowController(ICashFlowService cashFlowService,
                                INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {
            _cashFlowService = cashFlowService;
        }

        // GET: api/cashflow
        [HttpGet("{startDate}/{endDate}")]
        public async Task<ActionResult<CashFlow>> GetRange(DateTime startDate, DateTime endDate, int companyID )
        {            
            return await _cashFlowService.GetByRangeAsync(startDate, endDate, companyID);
        }
    }
}
