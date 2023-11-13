using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class addWeatherWidget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "widgets",
                columns: new[] { "id", "content", "height", "name", "width" },
                values: new object[] { 3, "_Weather", 2, "Weather", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
