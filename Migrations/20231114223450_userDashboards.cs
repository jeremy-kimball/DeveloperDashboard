using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class userDashboards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "application_user_id",
                table: "dashboards",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_dashboards_application_user_id",
                table: "dashboards",
                column: "application_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_dashboards_users_application_user_id",
                table: "dashboards",
                column: "application_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_dashboards_users_application_user_id",
                table: "dashboards");

            migrationBuilder.DropIndex(
                name: "ix_dashboards_application_user_id",
                table: "dashboards");

            migrationBuilder.DropColumn(
                name: "application_user_id",
                table: "dashboards");
        }
    }
}
