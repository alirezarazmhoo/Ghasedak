using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.CreateTable(
                name: "DischargeRoutes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(maxLength: 10, nullable: true),
                    day = table.Column<int>(maxLength: 10, nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeRoutes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Boxs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    number = table.Column<string>(maxLength: 10, nullable: true),
                    fullName = table.Column<string>(maxLength: 100, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    assignmentDate = table.Column<string>(maxLength: 20, nullable: true),
                    dischargeRouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Boxs_DischargeRoutes_dischargeRouteId",
                        column: x => x.dischargeRouteId,
                        principalTable: "DischargeRoutes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoxIncomes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    factorNumber = table.Column<string>(maxLength: 20, nullable: true),
                    price = table.Column<long>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    lon = table.Column<double>(nullable: false),
                    lat = table.Column<double>(nullable: false),
                    boxId = table.Column<int>(nullable: false),
                    registerDate = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxIncomes", x => x.id);
                    table.ForeignKey(
                        name: "FK_BoxIncomes_Boxs_boxId",
                        column: x => x.boxId,
                        principalTable: "Boxs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoxIncomes_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxIncomes_boxId",
                table: "BoxIncomes",
                column: "boxId");

            migrationBuilder.CreateIndex(
                name: "IX_BoxIncomes_userId",
                table: "BoxIncomes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxs_dischargeRouteId",
                table: "Boxs",
                column: "dischargeRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxIncomes");

            migrationBuilder.DropTable(
                name: "Boxs");

            migrationBuilder.DropTable(
                name: "DischargeRoutes");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cityId = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.id);
                    table.ForeignKey(
                        name: "FK_Provinces_Cities_cityId",
                        column: x => x.cityId,
                        principalTable: "Cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    adminConfirmStatus = table.Column<int>(nullable: false),
                    cityId = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    countView = table.Column<int>(nullable: false),
                    createDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    expireDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    expireDateIsespacial = table.Column<DateTime>(maxLength: 50, nullable: false),
                    image = table.Column<string>(maxLength: 500, nullable: true),
                    isSpecial = table.Column<bool>(nullable: false),
                    lastPrice = table.Column<long>(nullable: false),
                    movie = table.Column<string>(maxLength: 500, nullable: true),
                    notConfirmDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    price = table.Column<long>(nullable: false),
                    provinceId = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 200, nullable: false),
                    totallDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notices_Cities_cityId",
                        column: x => x.cityId,
                        principalTable: "Cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notices_Provinces_provinceId",
                        column: x => x.provinceId,
                        principalTable: "Provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notices_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_cityId",
                table: "Notices",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_provinceId",
                table: "Notices",
                column: "provinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_userId",
                table: "Notices",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_cityId",
                table: "Provinces",
                column: "cityId");
        }
    }
}
