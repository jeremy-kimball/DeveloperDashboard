using Microsoft.AspNetCore.Identity;
namespace DeveloperDashboard.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Dashboard> Dashboards { get; set; }
    }
}
