using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
