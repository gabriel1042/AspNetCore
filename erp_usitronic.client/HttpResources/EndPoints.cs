using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.client.HttpResources
{
    public static class EndPoints
    {
        public const string USERS = "/v1/users";
        public const string COMPANIES = "/v1/companies";
        public const string BANKS = "/v1/banks";
        public const string PEOPLE = "/v1/people";
        public const string TOKEN = "/v1/auth";
        public const string STATES = "/v1/states";
        public const string ZIP_CODE = "https://viacep.com.br/ws/{0}/json/";
    }
}
