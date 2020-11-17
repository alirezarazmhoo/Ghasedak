using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class ghffg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAccessBox",
                table: "Charitys",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAccessFinancialAid",
                table: "Charitys",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAccessFlowerCrown",
                table: "Charitys",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAccessSponsor",
                table: "Charitys",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAccessBox",
                table: "Charitys");

            migrationBuilder.DropColumn(
                name: "isAccessFinancialAid",
                table: "Charitys");

            migrationBuilder.DropColumn(
                name: "isAccessFlowerCrown",
                table: "Charitys");

            migrationBuilder.DropColumn(
                name: "isAccessSponsor",
                table: "Charitys");
        }
    }
}
