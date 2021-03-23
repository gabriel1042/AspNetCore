using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Bank : BaseModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "balance")]
        public decimal Balance { get; set; }

        [DataMember(Name = "entersCashFlow")]
        public bool EntersCashFlow { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public Check Check { get; set; }

        [IgnoreDataMember]
        public Receipt Receipt { get; set; }

        [IgnoreDataMember]
        public Payment Payment { get; set; }

        [IgnoreDataMember]
        public FinancialMovement FinancialMovement { get; set; }
    }
}
