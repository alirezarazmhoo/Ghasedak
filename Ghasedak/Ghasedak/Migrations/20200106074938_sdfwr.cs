using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfwr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lat",
                table: "DischargeRoutes");

            migrationBuilder.DropColumn(
                name: "lon",
                table: "DischargeRoutes");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Boxs",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "lat",
                table: "Boxs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "lon",
                table: "Boxs",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Boxs");

            migrationBuilder.DropColumn(
                name: "lat",
                table: "Boxs");

            migrationBuilder.DropColumn(
                name: "lon",
                table: "Boxs");

            migrationBuilder.AddColumn<double>(
                name: "lat",
                table: "DischargeRoutes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "lon",
                table: "DischargeRoutes",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
