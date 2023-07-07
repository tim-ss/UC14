using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using UC14.WebApp.Models;

namespace UC14.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitsService unitsService;

        public HomeController(IUnitsService unitsService)
        {
            this.unitsService = unitsService;
        }

        public IActionResult Index()
        {
            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
            var model = new HomePageViewModel
            {
                Dates = new List<DateTime>
                {
                    new DateTime(2022, 12, 31),
                    new DateTime(1995, 6, 20),
                    new DateTime(1980, 3, 15),
                    DateTime.Now
                },
                Numbers = new List<double>
                {
                    100.12,
                    1000.123,
                    1000000.123456,
                    1000000000.123456789,
                },
                MeasurementUnitsSet = unitsService.GetUnitsSet(regionInfo.IsMetric),
                Distance = 100,
                Weight = 58,
                Volume = 67
            };

            return View(model);
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

        public IActionResult CultureNotSupportedError()
        {
            return View();
        }
    }
}