using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class ew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayType",
                table: "SponsorPays",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayType",
                table: "FlowerCrowns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayType",
                table: "FinancialAids",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayType",
                table: "SponsorPays");

            migrationBuilder.DropColumn(
                name: "PayType",
                table: "FlowerCrowns");

            migrationBuilder.DropColumn(
                name: "PayType",
                table: "FinancialAids");
        }
    }
}
