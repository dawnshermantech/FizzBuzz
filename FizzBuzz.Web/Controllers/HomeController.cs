using Microsoft.AspNetCore.Mvc;
using FizzBuzz.Web.Models;
using FizzBuzz.Web.Services;

namespace FizzBuzz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISharingCalculatorService _sharingCalculatorService;

        public HomeController(ISharingCalculatorService sharingCalculatorService)
        {
            _sharingCalculatorService = sharingCalculatorService;
        }

        [HttpGet]
        public IActionResult SharingCalculator()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SharingCalculator(SharingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _sharingCalculatorService.CalculateShareAsync(model);
                    ViewBag.Result = result;
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
