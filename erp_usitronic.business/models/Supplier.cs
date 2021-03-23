using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Supplier : BaseModel
    {
        [DataMember(Name = "companyName")]
        public string CompanyName { get; set; }

        [DataMember(Name = "stateRegistration")]
        public string StateRegistration { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public Person Person { get; set; }

        [DataMember(Name = "personId")]
        public int PersonId { get; set; }

        [IgnoreDataMember]
        public Payment Payment { get; set; }

    }
}
