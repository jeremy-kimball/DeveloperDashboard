namespace DeveloperDashboard.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Widget> Widgets { get; set; }
    }
}
