using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Person : BaseModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "kindPerson")]
        public char KindPerson { get; set; }

        [DataMember(Name = "idNumber")]
        public string IdNumber { get; set; }

        /* EF Relations */
        [DataMember(Name = "adresses")]
        public List<Address> Adresses { get; set; }

        [DataMember(Name = "emails")]
        public List<Email> Emails { get; set; }

        [DataMember(Name = "telephones")]
        public List<Telephone> Telephones { get; set; }

        [DataMember(Name = "supplier")]
        public Supplier Supplier { get; set; }

        [DataMember(Name = "customer")]
        public List<Customer> Customers { get; set; }

        //Transient
        [IgnoreDataMember]
        public Telephone FirstTelephone
        {
            get
            {
                if(Telephones!= null)
                {
                    if (Telephones.Count > 0)
                    {
                        return Telephones.First();
                    }
                }
                return null;
            }
        }

        [IgnoreDataMember]
        public Email FirstEmail
        {
            get
            {
                if (Emails != null)
                {
                    if (Emails.Count > 0)
                    {
                        return Emails.First();
                    }
                }
                return null;
            }
        }

        [IgnoreDataMember]
        public Address FirstAddress
        {
            get
            {
                if (Adresses != null)
                {
                    if (Adresses.Count > 0)
                    {
                        return Adresses.First();
                    }
                }
                return null;
            }
        }

        [DataMember(Name = "isSupplier")]
        public bool IsSupplier
        {
            get
            {
                return Supplier != null;
            }
        }
        [DataMember(Name = "isCustomer")]
        public bool IsCustomer
        {
            get
            {
                return Customers != null;
            }
        }
    }
}
