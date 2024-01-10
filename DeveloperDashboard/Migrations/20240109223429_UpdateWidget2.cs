using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWidget2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                column: "w",
                value: 4);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                column: "w",
                value: 8);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "h", "w" },
                values: new object[] { 8, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                column: "w",
                value: 2);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                column: "w",
                value: 2);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "h", "w" },
                values: new object[] { 2, 2 });
        }
    }
}
