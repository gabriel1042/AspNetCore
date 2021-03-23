using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class ApiToken : BaseModel
    {
        [DataMember(Name = "created")]
        public DateTime? Created { get; set; }

        [DataMember(Name = "expiration")]
        public DateTime? Expiration { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }
    }
}
