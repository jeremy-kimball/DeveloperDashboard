namespace DeveloperDashboard.Services
{
    public class UrlShortenerApiService : IUrlShortenerApiService
    {
        private static readonly HttpClient client;

        static UrlShortenerApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://ulvis.net")
            };
        }

        public async Task<string> GetShortLink(string link, string customName)
        {
            var url = string.Format("/api.php?url={0}&custom={1}", link, customName);
            string result = "";
            var response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                //throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
    }
}
