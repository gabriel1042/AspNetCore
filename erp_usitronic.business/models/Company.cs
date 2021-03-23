using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Company : BaseModel
    {
        [DataMember(Name = "companyName")]
        public string CompanyName { get; set; }

        [DataMember(Name = "cnpjNumber")]
        public string CnpjNumber { get; set; }

        [DataMember(Name = "stateRegistration")]
        public string StateRegistration { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public Receipt Receipt { get; set; }

        [IgnoreDataMember]
        public Payment Payment { get; set; }
    }
}
