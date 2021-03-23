using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace erp_usitronic.client.HttpResources.Authentication
{
    public static class Token
    {
        public static DateTime DateTimeEndValidate { get; set; }
        public static string Key { get; set; }
        public static string AccessCode { get; set; }

        public static async Task<bool> RecoveryAsync()
        {
            try
            {
                TokenBody tokenBody = new TokenBody();
                if (string.IsNullOrEmpty(Key))
                    await GetNewAsync(tokenBody);
                else
                    await UpdateAsync(tokenBody);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> GetNewAsync(TokenBody tokenBody)
        {
            try
            {
                var json = JsonConvert.SerializeObject(tokenBody);
                HttpResponseMessage response = await HttpUtilities.PostAsync(EndPoints.TOKEN, json, false);
                if ((response.StatusCode == HttpStatusCode.Unauthorized) || (response.StatusCode == HttpStatusCode.BadRequest))
                {
                    return false;
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(jsonResponse);
                    SetKey(tokenResponse.AccessToken, tokenResponse.Expiration, tokenBody.AccessKey);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task<bool> UpdateAsync(TokenBody tokenBody)
        {
            try
            {
                if (DateTime.Now > DateTimeEndValidate)
                {
                    await GetNewAsync(tokenBody);
                }
                return true;
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                    return await GetNewAsync(tokenBody);
                else
                    throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SetKey(string key, DateTime expiresIn, string accessCode)
        {
            try
            {
                Key = key;
                DateTimeEndValidate = expiresIn;
                AccessCode = accessCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
