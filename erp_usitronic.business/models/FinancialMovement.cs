using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class FinancialMovement : BaseModel
    {
        [DataMember(Name = "transctionDate")]
        public DateTime? TransactionDate { get; set; }

        [DataMember(Name = "previousBalance")]
        public decimal PreviousBalance { get; set; }

        [DataMember(Name = "transactionValue")]
        public decimal TransactionValue { get; set; }

        [DataMember(Name = "afterBalance")]
        public decimal AfterBalance { get; set; }

        [DataMember(Name = "kind")]
        public char Kind { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public Bank Bank { get; set; }

        [DataMember(Name = "bankId")]
        public int BankId { get; set; }

    }
}
