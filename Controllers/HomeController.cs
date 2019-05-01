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
        public ActionResult<IEnumerable<string>> Index()
        {            
            using (HttpClient client = new HttpClient())
               {
                    ViewBag.List = Api.Get("Values");

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
