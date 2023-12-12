using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class googleSearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "widgets",
                columns: new[] { "id", "content", "height", "name", "width" },
                values: new object[] { 2, "_GoogleSearch", 2, "Google Search", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
