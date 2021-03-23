using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.client.HttpResources.Authentication;
using Newtonsoft.Json;

namespace erp_usitronic.client.HttpResources
{
    public class HttpUtilities
    {
        public const string CONECTION_FAIL_CODES = "401,408,502,503,504";
        private const string AGENT_NAME = "Erp_Usitronic_Client";
        public const string BASE_URL = "https://localhost:5001/api";

        public static async Task<HttpResponseMessage> PostAsync(string endPoint, string json, bool autenticar)
        {
            HttpResponseMessage response = null;
            HttpClient httpClient = new HttpClient();
            try
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (autenticar)
                {
                    await Token.RecoveryAsync();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Key);
                }
                ProductHeaderValue produtoHeaderValue = new ProductHeaderValue(AGENT_NAME, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                ProductInfoHeaderValue productInfoHeaderValue = new ProductInfoHeaderValue(produtoHeaderValue);
                httpClient.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue);
                response = await httpClient.PostAsync($"{BASE_URL}{endPoint}",
                                    new StringContent(json, Encoding.UTF8, "application/json"));

                return response;
            }
            catch
            {
                throw;
            }
        }
       
        public static async Task<HttpResponseMessage> PostAsync(string url, string json)
        {
            try
            {
                return await PostAsync(url, json, true);
            }
            catch
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PostAsync(string url, object entity)
        {
            try
            {
                var json = JsonConvert.SerializeObject(entity);
                return await PostAsync(url, json);
            }
            catch
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PutAsync(string endPoint, string json)
        {

            HttpResponseMessage response = null;
            HttpClient httpClient = new HttpClient();
            try
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await Token.RecoveryAsync();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Key);
                ProductHeaderValue produtoHeaderValue = new ProductHeaderValue(AGENT_NAME, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                ProductInfoHeaderValue productInfoHeaderValue = new ProductInfoHeaderValue(produtoHeaderValue);
                httpClient.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue);
                response = await httpClient.PutAsync($"{BASE_URL}{endPoint}",
                                    new StringContent(json, Encoding.UTF8, "application/json"));

                return response;

            }
            catch
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PutAsync(string endPoint)
        {
            try
            {
                return await PutAsync(endPoint, "");
            }
            catch
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> PutAsync(string endPoint, object entity)
        {
            try
            {
                var json = JsonConvert.SerializeObject(entity);
                return await PutAsync(endPoint, json);
            }
            catch
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> GetAsync(string endPoint, Dictionary<string, object> headers)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key.ToString(), header.Value.ToString());
                }
                await Token.RecoveryAsync();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Key);
                ProductHeaderValue produtoHeaderValue = new ProductHeaderValue(AGENT_NAME, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                ProductInfoHeaderValue productInfoHeaderValue = new ProductInfoHeaderValue(produtoHeaderValue);
                httpClient.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue);
                var response = httpClient.GetAsync($"{BASE_URL}{endPoint}").Result;
                return response;
            }
            catch
            {
                throw;
            }
        }

        public static ZipCodeModel GetZipCode(string zipCode)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                ProductHeaderValue produtoHeaderValue = new ProductHeaderValue(AGENT_NAME, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                ProductInfoHeaderValue productInfoHeaderValue = new ProductInfoHeaderValue(produtoHeaderValue);
                httpClient.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue);
                var response = httpClient.GetAsync(string.Format(EndPoints.ZIP_CODE,zipCode)).Result;
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<ZipCodeModel>(json);                    
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }


        public static async Task<HttpResponseMessage> GetAsync(string endPoint)
        {
            try
            {
                Dictionary<string, object> nothing = new Dictionary<string, object>();
                return await GetAsync(endPoint, nothing);
            }
            catch
            {
                throw;
            }
        }

        public static async Task<HttpResponseMessage> DeleteAsync(string endPoint)
        {
            HttpResponseMessage response = null;
            HttpClient httpClient = new HttpClient();
            try
            {
                await Token.RecoveryAsync();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.Key);
                ProductHeaderValue produtoHeaderValue = new ProductHeaderValue(AGENT_NAME, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                ProductInfoHeaderValue productInfoHeaderValue = new ProductInfoHeaderValue(produtoHeaderValue);
                httpClient.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue);
                response = httpClient.DeleteAsync($"{BASE_URL}{endPoint}").Result;
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
