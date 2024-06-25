using FizzBuzz.Api.Models;
using FizzBuzz.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SharingCalculationController : ControllerBase
    {
        private readonly ISharingCalculatorService _sharingCalculatorService;

        public SharingCalculationController(ISharingCalculatorService sharingCalculatorService)
        {
            _sharingCalculatorService = sharingCalculatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SharingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _sharingCalculatorService.CalculateShareAsync(model);
            return Ok(result);
        }
    }
}
