using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Receipt : BaseModel
    {
        [DataMember(Name = "receiptDate")]
        public DateTime? ReceiptDate { get; set; }

        [DataMember(Name = "receiptValue")]
        public decimal ReceiptValue { get; set; }

        [DataMember(Name = "invoiceNumber")]
        public int? InvoiceNumber { get; set; }

        [DataMember(Name = "shippingSituation")]
        public string ShippingSituation { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "paid")]
        public bool Paid { get; set; }
        
        /* EF Relations */
        [IgnoreDataMember]
        public Company Company { get; set; }

        [DataMember(Name = "companyId")]
        public int CompanyId { get; set; }

        [IgnoreDataMember]
        public Customer Customer { get; set; }

        [DataMember(Name = "customerId")]
        public int CustomerId { get; set; }
        
        [IgnoreDataMember]
        public Bank Bank { get; set; }

        [DataMember(Name= "bankId")]
        public int BankId { get; set; }

    }

    [DataContract]
    public class ReceiptPaid : BaseModel
    {
        [DataMember(Name = "paid")]
        public bool Paid { get; set; }
    }
}
