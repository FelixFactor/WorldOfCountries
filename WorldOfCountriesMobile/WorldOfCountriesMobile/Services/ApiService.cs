using System;
using System.Collections.Generic;
using System.Net.Http;
namespace WorldOfCountriesMobile.Prism.Services
{
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using WorldOfCountriesMobile.Prism.Models;

    public class ApiService : IApiService
    {
        private protected string urlBase = App.Current.Resources["UrlAPI"].ToString();
        private protected string servicePrefix = "/rest/v2/";
        public async Task<Response> GetListAsync<T>(string controller)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Success = false,
                        Message = response.ReasonPhrase,
                    };
                }
                
                //defines options so null values don't return errors
                var options = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                var list = JsonConvert.DeserializeObject<List<CountryResponse>>(await response.Content.ReadAsStringAsync(), options);
                return new Response
                {
                    Success = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
