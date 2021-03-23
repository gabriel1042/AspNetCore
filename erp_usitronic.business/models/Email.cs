using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Email : BaseModel
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public Person Person { get; set; }

        [DataMember(Name = "personId")]
        public int PersonId { get; set; }
    }
}
