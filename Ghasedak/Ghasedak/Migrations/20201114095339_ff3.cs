using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class ff3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deceasedName",
                table: "FlowerCrowns");

            migrationBuilder.DropColumn(
                name: "donator",
                table: "FlowerCrowns");

            migrationBuilder.AddColumn<int>(
                name: "deceasedNameId",
                table: "FlowerCrowns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "donatorId",
                table: "FlowerCrowns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeceasedNames",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deceasedFullName = table.Column<string>(maxLength: 100, nullable: true),
                    deceaseAalias = table.Column<string>(maxLength: 100, nullable: true),
                    deceasedSex = table.Column<bool>(nullable: false),
                    charityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeceasedNames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Donators",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    donatorFullName = table.Column<string>(maxLength: 100, nullable: true),
                    donatorAlias = table.Column<string>(maxLength: 100, nullable: true),
                    charityId = table.Column<int>(nullable: false),
                    donatorMobile = table.Column<string>(maxLength: 11, nullable: true),
                    isSendMessage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donators", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerCrowns_deceasedNameId",
                table: "FlowerCrowns",
                column: "deceasedNameId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerCrowns_donatorId",
                table: "FlowerCrowns",
                column: "donatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerCrowns_DeceasedNames_deceasedNameId",
                table: "FlowerCrowns",
                column: "deceasedNameId",
                principalTable: "DeceasedNames",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerCrowns_Donators_donatorId",
                table: "FlowerCrowns",
                column: "donatorId",
                principalTable: "Donators",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerCrowns_DeceasedNames_deceasedNameId",
                table: "FlowerCrowns");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowerCrowns_Donators_donatorId",
                table: "FlowerCrowns");

            migrationBuilder.DropTable(
                name: "DeceasedNames");

            migrationBuilder.DropTable(
                name: "Donators");

            migrationBuilder.DropIndex(
                name: "IX_FlowerCrowns_deceasedNameId",
                table: "FlowerCrowns");

            migrationBuilder.DropIndex(
                name: "IX_FlowerCrowns_donatorId",
                table: "FlowerCrowns");

            migrationBuilder.DropColumn(
                name: "deceasedNameId",
                table: "FlowerCrowns");

            migrationBuilder.DropColumn(
                name: "donatorId",
                table: "FlowerCrowns");

            migrationBuilder.AddColumn<string>(
                name: "deceasedName",
                table: "FlowerCrowns",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "donator",
                table: "FlowerCrowns",
                maxLength: 100,
                nullable: true);
        }
    }
}
