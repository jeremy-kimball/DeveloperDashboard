using DeveloperDashboard.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace DeveloperDashboard.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private static readonly HttpClient client;

        static WeatherApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://weather.visualcrossing.com/")
            };
        }

        public async Task<WeatherApiResponse> GetWeather(string location)
        {
            var url = string.Format("VisualCrossingWebServices/rest/services/timeline/{0}?unitGroup=us&elements=datetime%2Ctempmax%2Ctempmin%2Ctemp&include=days&key=YPVGFDDDN9GB42Y35ZRPPHJQA&contentType=json", location);
            var result = new WeatherApiResponse();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<WeatherApiResponse>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
