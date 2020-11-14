using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class dfgd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Oprators");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Oprators");

            migrationBuilder.DropColumn(
                name: "imageName",
                table: "Oprators");

            migrationBuilder.DropColumn(
                name: "nationalcode",
                table: "Oprators");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Oprators");

            migrationBuilder.AddColumn<string>(
                name: "passwordShow",
                table: "Oprators",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordShow",
                table: "Oprators");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Oprators",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Oprators",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageName",
                table: "Oprators",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nationalcode",
                table: "Oprators",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Oprators",
                nullable: false,
                defaultValue: false);
        }
    }
}
