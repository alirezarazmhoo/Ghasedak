using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class qsf4253 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SponsorPays",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    price = table.Column<long>(nullable: true),
                    recieverCode = table.Column<string>(maxLength: 30, nullable: true),
                    deviceCode = table.Column<string>(maxLength: 30, nullable: true),
                    terminalCode = table.Column<string>(maxLength: 30, nullable: true),
                    charityId = table.Column<int>(nullable: false),
                    opratorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorPays", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fullName = table.Column<string>(maxLength: 100, nullable: true),
                    code = table.Column<string>(maxLength: 30, nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    nationalcode = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 10, nullable: true),
                    birthDate = table.Column<string>(maxLength: 30, nullable: true),
                    charityId = table.Column<int>(nullable: false),
                    opratorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sponsors_Charitys_charityId",
                        column: x => x.charityId,
                        principalTable: "Charitys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_charityId",
                table: "Sponsors",
                column: "charityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SponsorPays");

            migrationBuilder.DropTable(
                name: "Sponsors");
        }
    }
}
