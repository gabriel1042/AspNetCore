using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class CashFlowDay
    {
        [DataMember(Name = "date")]
        public DateTime? Date { get; set; }

        [DataMember(Name = "payments")]
        public List<Payment> Payments { get; set; }

        [DataMember(Name = "receipts")]
        public List<Receipt> Receipts { get; set; }

        [DataMember(Name = "dayBalance")]
        public decimal DayBalace { get; set; }

        public CashFlowDay()
        {
            Payments = new List<Payment>();
            Receipts = new List<Receipt>();
        }
    }
}
