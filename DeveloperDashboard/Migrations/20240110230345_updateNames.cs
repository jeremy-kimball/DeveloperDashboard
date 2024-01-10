using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class updateNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Url_Shortener");

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Google_Search");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Url Shortener");

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Google Search");
        }
    }
}
