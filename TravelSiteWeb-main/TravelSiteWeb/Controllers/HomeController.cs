using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelSiteWeb.Models;
using TravelSiteWeb.Services;
using TravelSiteWeb.ViewModel;
using TravelSiteWeb.Data;

namespace TravelSiteWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MappingService _mappingService;
        public HomeController(ILogger<HomeController> logger, MappingService mappingService)
        {
            _logger = logger;
            _mappingService = mappingService;
        }

        private IEnumerable<TravelDetail> travel = new
        List<TravelDetail>
        {
            new TravelDetail
            {
                Id = 1,
                Name = "Caracas",
                Country = "Venesuela",
                Cost = 1590

            },
            new TravelDetail
            {
                Id= 2,
                Name = "Philippines",
                Country = "Philippines",
                Cost = 1900
            },

        };

        public IActionResult ClientOrder([FromServices] TripContext context)
        {
            var clientOrderViewModels = _mappingService.GetClientOrderViewModels(context);
            return View(clientOrderViewModels);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult caracas()
        {
            return View();
        }

        public IActionResult philippines()
        {
            return View();
        }

        public IActionResult OurTrips()
        {
            return View(travel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
