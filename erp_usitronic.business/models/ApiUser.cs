using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class ApiUser : BaseModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "accessKey")]
        public string AccessKey { get; set; }

        [DataMember(Name = "permissions")]
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
