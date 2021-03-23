using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace erp_usitronic.business.models
{
    [DataContract]
    public class Permission : BaseModel
    {
        [DataMember(Name = "resource")]
        public string Resource { get; set; }

        [DataMember(Name = "method")]
        public string Method { get; set; }

        [DataMember(Name = "authorized")]
        public bool Authorized { get; set; }

        /* EF Relations */
        [IgnoreDataMember]
        public ApiUser ApiUser { get; set; }

        [DataMember(Name = "apiUserId")]
        public int ApiUserId { get; set; }
    }

    public static class ResourcesPermissions
    {
        public const string ADRESSES = "ADRESSES";
        public const string BANKS = "BANKS";
        public const string CASH_FLOW = "CASH_FLOW";
        public const string CHECKS = "CHECKS";
        public const string CITIES = "CITIES";
        public const string COMPANIES = "COMPANIES";
        public const string CUSTOMERS = "CUSTOMERS";
        public const string EMAILS = "EMAILS";
        public const string FINANCIAL_MOVEMENTS = "FINANCIAL_MOVEMENTS";
        public const string PAYMENTS = "PAYMENTS";
        public const string PEOPLE = "PEOPLE";
        public const string RECEIPTS = "RECEIPTS";
        public const string STATES = "STATES";
        public const string SUPPLIERS = "SUPPLIERS";
        public const string TELEPHONES = "TELEPHONES";
    }

    public static class MethodsPermissions
    {
        public const string GET = "GET";
        public const string DELETE = "DELETE";
        public const string POST = "POST";
        public const string PUT = "PUT";
    }
}
