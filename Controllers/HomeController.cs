using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore.Models;
using dotnetcore.Classes;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace dotnetcore.Controllers
{
    public class HomeController : Controller
    {
        //private Api _api = new Api();

        public ActionResult<IEnumerable<string>> Index()
        {            
            using (HttpClient client = new HttpClient())
               {
                    client.BaseAddress = new Uri ("http://localhost:5000");
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    HttpResponseMessage response = client.GetAsync("/api/Values").Result;
                    string stringData = response.Content.ReadAsStringAsync().Result;
                    List<string> data = JsonConvert.DeserializeObject<List<string>>(stringData);
                    ViewBag.List = data;

                    return View();
                }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
