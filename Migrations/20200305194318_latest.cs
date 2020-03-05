using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_core_weather_api.Migrations
{
    public partial class latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Favorites");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Favorites",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Favorites",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Favorites",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
