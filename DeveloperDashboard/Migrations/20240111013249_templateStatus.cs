using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class templateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "template",
                table: "widgets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                column: "template",
                value: true);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                column: "template",
                value: true);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3,
                column: "template",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "template",
                table: "widgets");
        }
    }
}
