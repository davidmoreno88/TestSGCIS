using CodeTestSGCIS.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace CodeTestSGCIS.WebTelerik.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration _configuration;
        public HomeController(IConfiguration iConfig)
        {
            _configuration = iConfig;
        }


        public IActionResult Index()
        {
            return View("Page1");
        }

        public IActionResult Page1()
        {
            return View();
        }

        public async Task<IActionResult> Page2(int id)
        {
            string baseUrl = _configuration.GetSection("API").GetSection("URL").Value;
            var client = new RestClient(baseUrl + "Person");
            RestRequest restRequest = new RestRequest(Method.GET)
            {
                Resource = $"{id}"
            };
            IRestResponse response = await client.ExecuteAsync<PersonDto>(restRequest);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var dsResult = (JsonConvert.DeserializeObject<PersonDto>(response.Content));
                return View(dsResult);
            }
            return View();

        }

        public IActionResult Page3()
        {

            return View("Page3");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
