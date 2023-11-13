namespace DeveloperDashboard.Models
{
    public class WeatherApiResponse
    {
        public int QueryCost { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ResolvedAddress { get; set; }
        public string Address { get; set; }
        public string Timezone { get; set; }
        public double Tzoffset { get; set; }
        public List<DailyWeather> Days { get; set; }
    }
}
