using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfashfdfas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countExpireDate",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "countExpireDateIsespacial",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "wrongWord",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "logoName",
                table: "Settings",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sherkatName",
                table: "Settings",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logoName",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "sherkatName",
                table: "Settings");

            migrationBuilder.AddColumn<int>(
                name: "countExpireDate",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "countExpireDateIsespacial",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wrongWord",
                table: "Settings",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }
    }
}
