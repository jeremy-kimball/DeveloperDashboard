using DeveloperDashboard.Models;

namespace DeveloperDashboard.Services
{
    public interface IWeatherApiService
    {
        Task<WeatherApiResponse> GetWeather(string location);
    }
}
