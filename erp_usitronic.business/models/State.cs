using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class State : BaseModel 
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "initial")]
        public string Initial { get; set; }

        /* EF Relations */
        [DataMember(Name = "cities")]
        public IEnumerable<City> Cities { get; set; }
    }
}
