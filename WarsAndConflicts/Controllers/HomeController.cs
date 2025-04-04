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

        public HomeController(ILogger<HomeController> logger, IPeriodService periodService)
        {
            _logger = logger;
            _periodService = periodService;
        }

        public async Task<IActionResult> Index()
        {
            var periods = await _periodService.GetList();

            return View(periods);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
