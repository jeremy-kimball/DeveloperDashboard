using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace DeveloperDashboard.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Name { get; set; }
        public List<Widget> Widgets { get; set; }
    }
}
