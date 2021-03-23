using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.client
{
    [DataContract]
    public class ZipCodeModel
    {
        [DataMember(Name = "logradouro")]
        public string StreetName { get; set; }

        [DataMember(Name = "bairro")]
        public string Neightborhood { get; set; }

        [DataMember(Name = "localidade")]
        public string City { get; set; }

        [DataMember(Name = "uf")]
        public string State { get; set; }
    }
}
