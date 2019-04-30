using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace dotnetcore.Classes
{
    public class Api
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private Uri BaseEndpoint { get; set; }

        public async Task<List<string>> GetList()
        {
            BaseEndpoint = new Uri("http://localhost:5000");
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, 
                "/api/values"));
            return await GetAsync<List<string>>(requestUrl);
        }

        private async Task<T> GetAsync<T>(Uri requestUrl)
        {
            addHeaders();
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private void addHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("userIP");
            _httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
        }
    }
}