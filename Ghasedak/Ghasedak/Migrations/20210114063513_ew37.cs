using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class ew37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayType",
                table: "SponsorPays",
                newName: "payType");

            migrationBuilder.RenameColumn(
                name: "PayType",
                table: "FlowerCrowns",
                newName: "payType");

            migrationBuilder.RenameColumn(
                name: "PayType",
                table: "FinancialAids",
                newName: "payType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "payType",
                table: "SponsorPays",
                newName: "PayType");

            migrationBuilder.RenameColumn(
                name: "payType",
                table: "FlowerCrowns",
                newName: "PayType");

            migrationBuilder.RenameColumn(
                name: "payType",
                table: "FinancialAids",
                newName: "PayType");
        }
    }
}
