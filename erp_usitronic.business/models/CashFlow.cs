using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class CashFlow
    {
        [DataMember(Name = "cashFlowDays")]
        public List<CashFlowDay> CashFlowDays { get; set; }

        public CashFlow()
        {
            CashFlowDays = new List<CashFlowDay>();
        }
        
    }
}
