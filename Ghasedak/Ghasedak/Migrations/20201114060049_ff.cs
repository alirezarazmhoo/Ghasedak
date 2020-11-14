using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "opratorId",
                table: "DischargeRoutes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "opratorId",
                table: "Boxs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "opratorId",
                table: "DischargeRoutes");

            migrationBuilder.DropColumn(
                name: "opratorId",
                table: "Boxs");
        }
    }
}
