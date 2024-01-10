using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class addProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "properties",
                table: "widgets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "properties", "w" },
                values: new object[] { "gs-no-resize=\"true\"", 5 });

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "h", "properties" },
                values: new object[] { 1, "gs-no-resize=\"true\"" });

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "h", "properties" },
                values: new object[] { 3, "gs-no-resize=\"true\"" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "properties",
                table: "widgets");

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
                column: "h",
                value: 2);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3,
                column: "h",
                value: 8);
        }
    }
}
