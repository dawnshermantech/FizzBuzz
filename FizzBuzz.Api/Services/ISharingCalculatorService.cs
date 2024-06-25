using FizzBuzz.Api.Models;

namespace FizzBuzz.Api.Services
{
    public interface ISharingCalculatorService
    {
        Task<string> CalculateShareAsync(SharingModel request);
    }
}
