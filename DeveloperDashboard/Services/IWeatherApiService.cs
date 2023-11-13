using DeveloperDashboard.Models;

namespace DeveloperDashboard.Services
{
    public interface IWeatherApiService
    {
        Task<List<WeatherApiResponse>> GetWeather(string location);
    }
}
