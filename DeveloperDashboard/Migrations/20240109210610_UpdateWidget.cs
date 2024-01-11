using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWidget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "width",
                table: "widgets",
                newName: "y");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "widgets",
                newName: "x");

            migrationBuilder.AddColumn<int>(
                name: "h",
                table: "widgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "w",
                table: "widgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "h", "w", "x", "y" },
                values: new object[] { 2, 2, 0, 0 });

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "h", "w", "x", "y" },
                values: new object[] { 2, 2, 0, 0 });

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "h", "w", "x", "y" },
                values: new object[] { 2, 2, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "h",
                table: "widgets");

            migrationBuilder.DropColumn(
                name: "w",
                table: "widgets");

            migrationBuilder.RenameColumn(
                name: "y",
                table: "widgets",
                newName: "width");

            migrationBuilder.RenameColumn(
                name: "x",
                table: "widgets",
                newName: "height");

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "height", "width" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "height", "width" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "height", "width" },
                values: new object[] { 2, 2 });
        }
    }
}
