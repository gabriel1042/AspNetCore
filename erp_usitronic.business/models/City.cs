using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class City : BaseModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /* EF Relations */
        
        [IgnoreDataMember]
        public State State { get; set; }

        [DataMember(Name = "stateId")]
        public int StateId { get; set; }

        [IgnoreDataMember]
        public Address Address { get; set; }

    }
}
