namespace DeveloperDashboard.Models
{
    public class DashboardViewModel
    {
        public int[] SelectedWidgetIds { get; set; }
        public IEnumerable<Widget> AvailableWidgets { get; set; }
    }
}
