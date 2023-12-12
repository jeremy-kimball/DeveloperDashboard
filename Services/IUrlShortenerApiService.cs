namespace DeveloperDashboard.Services
{
    public interface IUrlShortenerApiService
    {
        Task<string> GetShortLink(string link);
    }
}
