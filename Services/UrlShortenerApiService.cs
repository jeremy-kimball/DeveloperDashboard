namespace DeveloperDashboard.Services
{
    public class UrlShortenerApiService : IUrlShortenerApiService
    {
        private static readonly HttpClient client;

        static UrlShortenerApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://tinyurl.com/")
            };
        }

        public async Task<string> GetShortLink(string link)
        {
            var url = string.Format("api-create.php?url={0}", link);
            string result = "";
            var response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
    }
}
