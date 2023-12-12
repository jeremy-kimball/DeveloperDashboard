using System.Runtime.CompilerServices;

namespace DeveloperDashboard.Models
{
    public class DailyWeather
    {
        public string Datetime { get; set; }
        public double Tempmax { get; set; }
        public double Tempmin { get; set; }
        public double Temp { get; set; }



        public string GetDay()
        {
            var converted = DateTime.Parse(Datetime);
            var day = converted.DayOfWeek.ToString();
            return day;
        }
    }
}
