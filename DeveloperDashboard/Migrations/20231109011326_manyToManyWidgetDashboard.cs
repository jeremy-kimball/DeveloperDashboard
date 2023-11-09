using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class manyToManyWidgetDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_widgets_dashboards_dashboard_id",
                table: "widgets");

            migrationBuilder.DropIndex(
                name: "ix_widgets_dashboard_id",
                table: "widgets");

            migrationBuilder.DropColumn(
                name: "dashboard_id",
                table: "widgets");

            migrationBuilder.CreateTable(
                name: "dashboard_widget",
                columns: table => new
                {
                    dashboards_id = table.Column<int>(type: "integer", nullable: false),
                    widgets_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dashboard_widget", x => new { x.dashboards_id, x.widgets_id });
                    table.ForeignKey(
                        name: "fk_dashboard_widget_dashboards_dashboards_id",
                        column: x => x.dashboards_id,
                        principalTable: "dashboards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dashboard_widget_widgets_widgets_id",
                        column: x => x.widgets_id,
                        principalTable: "widgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_dashboard_widget_widgets_id",
                table: "dashboard_widget",
                column: "widgets_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dashboard_widget");

            migrationBuilder.AddColumn<int>(
                name: "dashboard_id",
                table: "widgets",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "widgets",
                keyColumn: "id",
                keyValue: 1,
                column: "dashboard_id",
                value: null);

            migrationBuilder.CreateIndex(
                name: "ix_widgets_dashboard_id",
                table: "widgets",
                column: "dashboard_id");

            migrationBuilder.AddForeignKey(
                name: "fk_widgets_dashboards_dashboard_id",
                table: "widgets",
                column: "dashboard_id",
                principalTable: "dashboards",
                principalColumn: "id");
        }
    }
}
