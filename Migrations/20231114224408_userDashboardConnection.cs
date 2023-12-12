using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperDashboard.Migrations
{
    /// <inheritdoc />
    public partial class userDashboardConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_dashboards_users_application_user_id",
                table: "dashboards");

            migrationBuilder.RenameColumn(
                name: "application_user_id",
                table: "dashboards",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_dashboards_application_user_id",
                table: "dashboards",
                newName: "ix_dashboards_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_dashboards_users_user_id",
                table: "dashboards",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_dashboards_users_user_id",
                table: "dashboards");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "dashboards",
                newName: "application_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_dashboards_user_id",
                table: "dashboards",
                newName: "ix_dashboards_application_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_dashboards_users_application_user_id",
                table: "dashboards",
                column: "application_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }
    }
}
