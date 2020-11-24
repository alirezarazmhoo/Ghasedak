using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "Donators",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "DeceasedNames",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "guid",
                table: "Donators");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "DeceasedNames");
        }
    }
}
