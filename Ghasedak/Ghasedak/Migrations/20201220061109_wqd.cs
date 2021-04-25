using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class wqd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "boxKind",
                table: "Boxs",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "boxKind",
                table: "Boxs");
        }
    }
}
