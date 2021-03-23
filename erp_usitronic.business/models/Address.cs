using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Address : BaseModel
    {
        [DataMember(Name = "streetName")]
        public string StreetName { get; set; }

        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "neighborhood")]
        public string Neighborhood { get; set; }

        [DataMember(Name = "zipCode")]
        public string ZipCode { get; set; }
        
        /* EF Relations */
        [IgnoreDataMember]
        public Person Person { get; set; }
        
        [DataMember(Name = "personId")]
        public int PersonId { get; set; }

        [DataMember(Name = "city")]
        public City City { get; set; }

        [DataMember(Name = "cityId")]
        public int CityId { get; set; }
    }
}
