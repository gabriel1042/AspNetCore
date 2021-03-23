using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Payment : BaseModel
    {
        [DataMember(Name = "paymentDate")]
        public DateTime? PaymentDate { get; set; }

        [DataMember(Name = "paymentValue")]
        public decimal PaymentValue { get; set; }

        [DataMember(Name = "kindPayment")]
        public string KindPayment { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "paid")]
        public bool Paid { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public Company Company { get; set; }

        [DataMember(Name = "companyId")]
        public int CompanyId { get; set; }

        [IgnoreDataMember]
        public Supplier Supplier { get; set; }

        [DataMember(Name = "supplierId")]
        public int SupplierId { get; set; }

        [IgnoreDataMember]
        public Check Check { get; set; }

        [IgnoreDataMember]
        public Bank Bank { get; set; }

        [DataMember(Name = "bankId")]
        public int BankId { get; set; }
    }

    [DataContract]
    public class PaymentPaid : BaseModel
    {
        [DataMember(Name = "paid")]
        public bool Paid { get; set; }
    }
}
