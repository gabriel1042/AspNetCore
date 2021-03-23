using System;
using System.Threading.Tasks;
using erp_usitronic.api.Configuration;
using erp_usitronic.business.interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace erp_usitronic.tests
{
    [TestClass]
    public class CashFlowServiceTest
    {
        private ICashFlowService _cashFlowService;

        [TestInitialize]
        public void Setup()
        {
            _cashFlowService = DependecyInjectionConfig.GetService<ICashFlowService>();
        }

        [TestMethod]
        public async Task GetByRangeSuccessAsync()
        {
            var startDate = new DateTime(2021, 02, 01);
            var finishDate = new DateTime(2021, 02, 28);
            int companyId = 1;
            var cashFlow = await _cashFlowService.GetByRangeAsync(startDate, finishDate, companyId);

            Assert.IsTrue(cashFlow.CashFlowDays.Count>0);
        }
    }
}
