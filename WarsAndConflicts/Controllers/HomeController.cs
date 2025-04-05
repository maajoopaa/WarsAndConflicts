using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WarsAndConflicts.Application.Services;
using WarsAndConflicts.Models;

namespace WarsAndConflicts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPeriodService _periodService;
        private readonly IWarService _warService;

        public HomeController(ILogger<HomeController> logger, IPeriodService periodService, IWarService warService)
        {
            _logger = logger;
            _periodService = periodService;
            _warService = warService;
        }

        public async Task<ActionResult> Index()
        {
            var periods = await _periodService.GetList();

            return View(periods);
        }

        public async Task<ActionResult> Search(string query)
        {
            var wars = await _warService.Search(query);

            return View(wars);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
