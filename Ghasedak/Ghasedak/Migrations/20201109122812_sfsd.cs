using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sfsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "Sponsors");

            migrationBuilder.AddColumn<int>(
                name: "sponsorId",
                table: "SponsorPays",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SponsorPays_sponsorId",
                table: "SponsorPays",
                column: "sponsorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorPays_Sponsors_sponsorId",
                table: "SponsorPays",
                column: "sponsorId",
                principalTable: "Sponsors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SponsorPays_Sponsors_sponsorId",
                table: "SponsorPays");

            migrationBuilder.DropIndex(
                name: "IX_SponsorPays_sponsorId",
                table: "SponsorPays");

            migrationBuilder.DropColumn(
                name: "sponsorId",
                table: "SponsorPays");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "Sponsors",
                maxLength: 30,
                nullable: true);
        }
    }
}
