using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Omnia.DT4.Prosodic.App.Models;
using System.Diagnostics;

namespace Omnia.DT4.Prosodic.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var data = await GetProsodicsAsync();
            return View(data);
            
        }
        public async Task<ProsodicModel> GetProsodicsAsync()
        {
            ProsodicModel prosodic ;
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7030/api/prosodic/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prosodic= JsonConvert.DeserializeObject<ProsodicModel>(apiResponse);
                }
            }
            return  prosodic;
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
