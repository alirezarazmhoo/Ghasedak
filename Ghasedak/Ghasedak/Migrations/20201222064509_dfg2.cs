using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class dfg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "day",
                table: "DischargeRoutes");

            migrationBuilder.AddColumn<int>(
                name: "day",
                table: "Boxs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "day",
                table: "Boxs");

            migrationBuilder.AddColumn<int>(
                name: "day",
                table: "DischargeRoutes",
                nullable: true);
        }
    }
}
