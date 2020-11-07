using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharityId",
                table: "DischargeRoutes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharityId",
                table: "Boxs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharityId",
                table: "BoxIncomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Charitys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 100, nullable: true),
                    password = table.Column<string>(maxLength: 200, nullable: true),
                    title = table.Column<string>(maxLength: 30, nullable: true),
                    code = table.Column<string>(maxLength: 30, nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charitys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Oprators",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 50, nullable: true),
                    fullName = table.Column<string>(maxLength: 100, nullable: true),
                    code = table.Column<string>(maxLength: 30, nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    nationalcode = table.Column<string>(maxLength: 10, nullable: true),
                    imageName = table.Column<string>(maxLength: 500, nullable: true),
                    status = table.Column<bool>(nullable: false),
                    CharityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprators", x => x.id);
                    table.ForeignKey(
                        name: "FK_Oprators_Charitys_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charitys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DischargeRoutes_CharityId",
                table: "DischargeRoutes",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Oprators_CharityId",
                table: "Oprators",
                column: "CharityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DischargeRoutes_Charitys_CharityId",
                table: "DischargeRoutes",
                column: "CharityId",
                principalTable: "Charitys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DischargeRoutes_Charitys_CharityId",
                table: "DischargeRoutes");

            migrationBuilder.DropTable(
                name: "Oprators");

            migrationBuilder.DropTable(
                name: "Charitys");

            migrationBuilder.DropIndex(
                name: "IX_DischargeRoutes_CharityId",
                table: "DischargeRoutes");

            migrationBuilder.DropColumn(
                name: "CharityId",
                table: "DischargeRoutes");

            migrationBuilder.DropColumn(
                name: "CharityId",
                table: "Boxs");

            migrationBuilder.DropColumn(
                name: "CharityId",
                table: "BoxIncomes");
        }
    }
}
