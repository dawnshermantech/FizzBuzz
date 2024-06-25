using FizzBuzz.Web.Models;

namespace FizzBuzz.Web.Services
{
    public interface ISharingCalculatorService
    {
        Task<string> CalculateShareAsync(SharingModel request);
    }
}