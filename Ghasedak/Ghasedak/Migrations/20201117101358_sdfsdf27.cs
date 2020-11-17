using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfsdf27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historys");

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    opratorId = table.Column<int>(nullable: false),
                    charityId = table.Column<int>(nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserActivities_Oprators_opratorId",
                        column: x => x.opratorId,
                        principalTable: "Oprators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_opratorId",
                table: "UserActivities",
                column: "opratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.CreateTable(
                name: "Historys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    charityId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: true),
                    opratorId = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historys", x => x.id);
                    table.ForeignKey(
                        name: "FK_Historys_Oprators_opratorId",
                        column: x => x.opratorId,
                        principalTable: "Oprators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historys_opratorId",
                table: "Historys",
                column: "opratorId");
        }
    }
}
