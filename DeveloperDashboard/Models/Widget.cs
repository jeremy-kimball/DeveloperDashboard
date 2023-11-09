namespace DeveloperDashboard.Models
{
    public class Widget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Dashboard> Dashboards { get; set; }
    }
}
