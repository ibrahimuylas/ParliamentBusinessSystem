using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PBS.Core.Toolkit;
using PBS.Domain.Models;

namespace PBS.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPBSClient _client;

        public string APIUrl => _configuration["apiUrl"];

        public HomeController(IPBSClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<IActionResult> Events(string date)
        {
            TempData["DefaultDate"] = date??DateTime.Now.Date.ToString("yyyy-MM-dd");

            var result = await _client.GetJsonResult<List<EventModel>>($"{APIUrl}/GetEvents/{TempData["DefaultDate"]}");
            return View(result);
        }

        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<IActionResult> EventDetails(string date, int id)
        {
            var result = await _client.GetJsonResult<EventDetailsModel>($"{APIUrl}/GetEventDetails/{date ?? DateTime.Now.Date.ToString("yyyy-MM-dd")}/{id}");
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
