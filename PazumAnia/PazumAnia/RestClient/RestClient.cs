using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PazumAnia.RestClient
{
   public class RestClient<T>
    {
        private const string WebserviceUrl = "http://localhost:59310/api/Users/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebserviceUrl);
            var users = JsonConvert.DeserializeObject<List<T>>(json);
            return users;
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(WebserviceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }
    }
}
