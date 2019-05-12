using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PBS.Domain.Models;

namespace PBS.UI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Events(string date)
        {
            TempData["DefaultDate"] = date??DateTime.Now.Date.ToString("yyyy-MM-dd");

            var result = new List<EventModel>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/api/GetEvents/{date}");
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<List<EventModel>>(await response.Content.ReadAsStringAsync());
                }
            }

            return View(result);
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
