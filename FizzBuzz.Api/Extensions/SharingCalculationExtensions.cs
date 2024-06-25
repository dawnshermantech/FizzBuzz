using FizzBuzz.Api.Models;

namespace FizzBuzz.Api.Extensions
{
    public static class SharingCalculationExtensions
    {
        public static string MapSharingResponse(this SharingModel request, string welcomeMessage)
        {
            string nameMessage = string.IsNullOrWhiteSpace(request.Name) ? "" : $"{request.Name}";
            welcomeMessage = $"{welcomeMessage} {nameMessage}! ";
            string response;

            if (string.IsNullOrWhiteSpace(request.Share))
            {
                response = "Invalid Item - empty value";
            }
            else if (double.TryParse(request.Share, out double shareValue))
            {
                if (int.TryParse(request.Share, out int intValue))
                {
                    // it is an integer, check to see if it is divisible
                    if (intValue % 3 == 0 && intValue % 5 == 0)
                    {
                        response = $"FizzBuzz - The value {intValue} is divisible by both 3 and 5.";
                    }
                    else if (intValue % 3 == 0)
                    {
                        response = $"Fizz - The value {intValue} is divisible by 3.";
                    }
                    else if (intValue % 5 == 0)
                    {
                        response = $"Buzz - The value {intValue} is divisible by 5.";
                    }
                    else if (intValue == 1)
                    {
                        var three = Math.Round((double)intValue / 3, 2).ToString("F2"); // Restrict to two decimal points
                        var five = Math.Round((double)intValue / 5, 2).ToString("F2"); // Restrict to two decimal points
                        string v = $"The value {intValue} is a whole number so let's calculate it!";
                        string t = $"1 Divided by 3 is {three}";
                        string f = $"1 Divided by 5 is {five}";
                        response = $"Ahhhhhh Number 1! {v} - {t} - {f}";
                    }
                    else if (intValue == 23)
                    {
                        var three = Math.Round((double)intValue / 3, 2).ToString("F2"); // Restrict to two decimal points
                        var five = Math.Round((double)intValue / 5, 2).ToString("F2"); // Restrict to two decimal points
                        string v = $"The value {intValue} is a whole number so let's calculate it!";
                        string t = $"23 Divided by 3 is {three}";
                        string f = $"23 Divided by 5 is {five}";
                        response = $"Ooooooh 23! {v} - {t} - {f}";
                    }
                    else
                    {
                        response = $"The value {intValue} is a whole number but not divisible by 3 or 5.";
                    }
                }
                else
                {
                    // It is a number, and it is a decimal
                    response = $"The value {shareValue} is a decimal number. Getting fancy!";
                }
            }
            else if (string.Equals(request.Share, "A", StringComparison.OrdinalIgnoreCase)) // Case insensitive check for the letter A
            {
                response = "Invalid Item - A";
            }
            else
            {
                // It is not a number
                response = $"The value '{request.Share}' is not a number, but you knew that!";
            }

            return $"{welcomeMessage} {response}";
        }
    }
}
