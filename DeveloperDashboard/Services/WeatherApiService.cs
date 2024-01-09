using DeveloperDashboard.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DeveloperDashboard.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient client;
        private readonly IConfiguration _configuration;

        public WeatherApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://weather.visualcrossing.com/")
            };
        }

        public async Task<WeatherApiResponse> GetWeather(string location)
        {
            //retrieve api key based on local or deployed
            string apikey = Environment.GetEnvironmentVariable("WEATHERAPIKEY") == null ? _configuration["WEATHERAPIKEY"] : Environment.GetEnvironmentVariable("WEATHERAPIKEY");
            var url = string.Format("VisualCrossingWebServices/rest/services/timeline/{0}?unitGroup=us&elements=datetime%2Ctempmax%2Ctempmin%2Ctemp&include=days&key={1}&contentType=json", location, apikey);
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

