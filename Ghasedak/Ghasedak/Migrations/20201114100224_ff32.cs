using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class ff32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerCrowns_Donators_donatorId",
                table: "FlowerCrowns");

            migrationBuilder.DropIndex(
                name: "IX_FlowerCrowns_donatorId",
                table: "FlowerCrowns");

            migrationBuilder.AddColumn<int>(
                name: "IntroducedId",
                table: "FlowerCrowns",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntroducedId",
                table: "FlowerCrowns");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerCrowns_donatorId",
                table: "FlowerCrowns",
                column: "donatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerCrowns_Donators_donatorId",
                table: "FlowerCrowns",
                column: "donatorId",
                principalTable: "Donators",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
