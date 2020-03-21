using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PazumAnia.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PazumAnia.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            //Creating new http client
            var client = new HttpClient();

            //Building model using passed parameters
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            //Convert model to Json form
            var json = JsonConvert.SerializeObject(model);

            //Create http content
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Save response from the server
            var response = await client.PostAsync("http://192.168.0.129:8020/api/Account/Register", content);

            //Return successcode
            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            //Build a new KeyValuePair for three variables
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password"),
            };

            //Create request for the Token
            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.0.129:8020/Token");

            //Pass keyValues to the request content
            request.Content = new FormUrlEncodedContent(keyValues);

            //Create new HttpClient
            var client = new HttpClient();

            //Save response from the server
            var response = await client.SendAsync(request);

            //Convert response content as string
            var jwt = await response.Content.ReadAsStringAsync();

            //Dynamic deserialize objetct 
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            //Take AccessToken from deserialized object 
            var accessToken = jwtDynamic.Value<string>("access_token");

            //Write AccessToken to the output console
            Debug.WriteLine(jwt);

            //Return accessToken
            return accessToken;
        }
        public async Task<List<Idea>> GetIdeasAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync("http://192.168.0.129:8020/api/ideas");

            var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

            return ideas;
        }
        public async Task PostIdeasAsync(Idea idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(idea);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://192.168.0.129:8020/api/ideas", content);
        }
        public async Task PutIdeaAsync(Idea idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(idea);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync("http://192.168.0.129:8020/api/ideas/" + idea.Id, content);

            var bolean = response.IsSuccessStatusCode;

        }
        public async Task DeleteIdeaAsync(int id, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync("http://192.168.0.129:8020/api/ideas/" + id);

        }

    }
}
