using System.Net;
using System.Web;

namespace DeveloperDashboard.Helper
{
    public static class ConnectionHelper
    {




        public static string getConnectionString()
        {
            string DEVELOPERDASHBOARD_DBCONNECTIONSTRING = "";
            if (Environment.GetEnvironmentVariable("PGHOST") != null)
            {
                DEVELOPERDASHBOARD_DBCONNECTIONSTRING = $"Server={Environment.GetEnvironmentVariable("PGHOST")};Database={Environment.GetEnvironmentVariable("DATABASE_URL")};Port={Environment.GetEnvironmentVariable("PGPORT")};Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};Password={Environment.GetEnvironmentVariable("PGPASSWORD")}";
            }
            else
            {
                DEVELOPERDASHBOARD_DBCONNECTIONSTRING = "Server=localhost;Database=DeveloperDashboardDB;Port=5432;Username=postgres;Password=password123";
            }
            return DEVELOPERDASHBOARD_DBCONNECTIONSTRING;
        }
    }
}
