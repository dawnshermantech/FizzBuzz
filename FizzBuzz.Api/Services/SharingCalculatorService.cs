using FizzBuzz.Api.Extensions;
using FizzBuzz.Api.Models;

namespace FizzBuzz.Api.Services
{
    public class SharingCalculatorService : ISharingCalculatorService
    {
        public async Task<string> CalculateShareAsync(SharingModel request)
        {
            await Task.Delay(100); // Simulating the async work :)
            string welcomeMessage = "Welcome";
            string response = request.MapSharingResponse(welcomeMessage);

            return response;
        }
    }
}
