using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.client.HttpResources.Authentication
{
    [DataContract]
    public class TokenBody
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "accessKey")]
        public string AccessKey { get; set; }

        public TokenBody()
        {
            Name = Config.User;
            AccessKey = Config.Password;
        }
    }
}
