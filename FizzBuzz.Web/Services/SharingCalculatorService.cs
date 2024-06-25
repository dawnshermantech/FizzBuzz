using FizzBuzz.Web.Models;

namespace FizzBuzz.Web.Services
{
    public class SharingCalculatorService : ISharingCalculatorService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SharingCalculatorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> CalculateShareAsync(SharingModel request)
        {
            var apiUrl = _configuration["ApiUrl"]; 
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{apiUrl}/api/SharingCalculation", request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error occurred while calling the API. Status code: {response.StatusCode}, Error: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Error occurred while calling the API: {ex.Message}", ex);
            }
        }
    }
}
