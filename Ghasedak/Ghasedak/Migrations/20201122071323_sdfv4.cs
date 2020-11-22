using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Donators",
                newName: "guidDonator");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "DeceasedNames",
                newName: "guidDeceasedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "guidDonator",
                table: "Donators",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "guidDeceasedName",
                table: "DeceasedNames",
                newName: "guid");
        }
    }
}
