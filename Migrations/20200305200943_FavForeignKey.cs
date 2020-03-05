using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_core_weather_api.Migrations
{
    public partial class FavForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Favorites",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_UserID",
                table: "Favorites",
                newName: "IX_Favorites_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Favorites",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                newName: "IX_Favorites_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
