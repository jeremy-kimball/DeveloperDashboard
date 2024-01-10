
using Newtonsoft.Json;

namespace DeveloperDashboard.Models
{
    public class Widget
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonProperty(Order = -2)]
        public string Content { get; set; }

        [JsonProperty(Order = -4)]
        public int W { get; set; }

        [JsonProperty(Order = -3)]
        public int H { get; set; }

        [JsonProperty(Order = -6)]
        public int X { get; set; }

        [JsonProperty(Order = -5)]
        public int Y { get; set; }
        [JsonIgnore]
        public string Properties { get; set; }
        [JsonIgnore]
        public List<Dashboard> Dashboards { get; set; }
    }
}
