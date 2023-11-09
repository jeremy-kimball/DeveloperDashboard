using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "widgets",
                columns: new[] { "id", "content", "dashboard_id", "height", "name", "width" },
                values: new object[] { 1, "_UrlShortener", null, 2, "Url Shortener", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
