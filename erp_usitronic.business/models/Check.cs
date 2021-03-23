using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Check : BaseModel
    {
        [DataMember(Name = "issuer")]
        public string Issuer { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public Bank Bank { get; set; }

        [DataMember(Name = "bankId")]
        public int BankId { get; set; }

        [IgnoreDataMember]
        public Payment Payment { get; set; }

        [DataMember(Name = "paymentId")]
        public int PaymentId { get; set; }
    }
}
