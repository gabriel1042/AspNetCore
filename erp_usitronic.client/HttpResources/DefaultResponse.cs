using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.client.HttpResources
{
    [DataContract]
    public class DefaultResponse
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "data")]
        public object Data { get; set; }

        [DataMember(Name = "errors")]
        public List<string> Errors { get; set; }

    }
}
