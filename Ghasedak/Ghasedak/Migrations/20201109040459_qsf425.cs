using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class qsf425 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialServiceTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    charityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialServiceTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialAids",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: true),
                    price = table.Column<long>(nullable: false),
                    charityId = table.Column<int>(nullable: true),
                    opratorId = table.Column<int>(nullable: true),
                    financialServiceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAids", x => x.id);
                    table.ForeignKey(
                        name: "FK_FinancialAids_Charitys_charityId",
                        column: x => x.charityId,
                        principalTable: "Charitys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialAids_FinancialServiceTypes_financialServiceTypeId",
                        column: x => x.financialServiceTypeId,
                        principalTable: "FinancialServiceTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAids_charityId",
                table: "FinancialAids",
                column: "charityId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialAids_financialServiceTypeId",
                table: "FinancialAids",
                column: "financialServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialAids");

            migrationBuilder.DropTable(
                name: "FinancialServiceTypes");
        }
    }
}
