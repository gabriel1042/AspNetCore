using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.client.HttpResources.Authentication
{
    [DataContract]
    public class TokenResponse
    {

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "expiration")]
        public DateTime Expiration { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

    }
}
