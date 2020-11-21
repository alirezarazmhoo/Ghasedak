using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class swd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "androidCode",
                table: "Charitys",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isOptional",
                table: "AndroidVersions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "androidCode",
                table: "Charitys");

            migrationBuilder.DropColumn(
                name: "isOptional",
                table: "AndroidVersions");
        }
    }
}
