using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace dotnetcore.Classes
{
    public static class Api
    {
        public static List<string> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                    client.BaseAddress = new Uri ("http://localhost:5000");
                    
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    
                    HttpResponseMessage response = client.GetAsync("/api/Values").Result;
                    
                    string stringData = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<string>>(stringData);
            }
        }
    }
}