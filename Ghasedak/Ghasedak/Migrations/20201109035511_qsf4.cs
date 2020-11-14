using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class qsf4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUss",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUss", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AndroidVersions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appAndroidUrl = table.Column<string>(maxLength: 70, nullable: true),
                    currVersion = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AndroidVersions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Charitys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 20, nullable: true),
                    password = table.Column<string>(maxLength: 200, nullable: true),
                    passwordShow = table.Column<string>(maxLength: 20, nullable: true),
                    title = table.Column<string>(maxLength: 30, nullable: true),
                    code = table.Column<string>(maxLength: 6, nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    mobile = table.Column<string>(maxLength: 11, nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charitys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUss",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    pageTelegramUrl = table.Column<string>(maxLength: 200, nullable: true),
                    pageInstagramUrl = table.Column<string>(maxLength: 200, nullable: true),
                    pageTwitterUrl = table.Column<string>(maxLength: 200, nullable: true),
                    email = table.Column<string>(maxLength: 200, nullable: true),
                    androidVersion = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUss", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FlowerCrownTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: true),
                    charityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerCrownTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleNameFa = table.Column<string>(maxLength: 1000, nullable: false),
                    RoleNameEn = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    logoName = table.Column<string>(maxLength: 500, nullable: true),
                    sherkatName = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    image = table.Column<string>(maxLength: 500, nullable: true),
                    link = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Stirs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stirs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DischargeRoutes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(maxLength: 10, nullable: true),
                    day = table.Column<int>(nullable: true),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    charityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeRoutes", x => x.id);
                    table.ForeignKey(
                        name: "FK_DischargeRoutes_Charitys_charityId",
                        column: x => x.charityId,
                        principalTable: "Charitys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    token = table.Column<string>(maxLength: 100, nullable: true),
                    status = table.Column<bool>(nullable: false),
                    charityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprators", x => x.id);
                    table.ForeignKey(
                        name: "FK_Oprators_Charitys_charityId",
                        column: x => x.charityId,
                        principalTable: "Charitys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowerCrowns",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    donator = table.Column<string>(maxLength: 100, nullable: true),
                    deceasedName = table.Column<string>(maxLength: 100, nullable: true),
                    price = table.Column<long>(nullable: false),
                    CeremonyType = table.Column<int>(nullable: false),
                    charityId = table.Column<int>(nullable: true),
                    opratorId = table.Column<int>(nullable: true),
                    flowerCrownTypeId = table.Column<int>(nullable: false),
                    registerDate = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerCrowns", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlowerCrowns_Charitys_charityId",
                        column: x => x.charityId,
                        principalTable: "Charitys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlowerCrowns_FlowerCrownTypes_flowerCrownTypeId",
                        column: x => x.flowerCrownTypeId,
                        principalTable: "FlowerCrownTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(maxLength: 100, nullable: true),
                    fullName = table.Column<string>(maxLength: 100, nullable: true),
                    password = table.Column<string>(maxLength: 200, nullable: true),
                    passwordShow = table.Column<string>(maxLength: 20, nullable: true),
                    token = table.Column<string>(maxLength: 100, nullable: true),
                    roleId = table.Column<int>(nullable: false),
                    code = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    assignmentDate = table.Column<string>(maxLength: 30, nullable: true),
                    dischargeRouteId = table.Column<int>(nullable: false),
                    lon = table.Column<double>(nullable: false),
                    lat = table.Column<double>(nullable: false),
                    address = table.Column<string>(maxLength: 500, nullable: true),
                    charityId = table.Column<int>(nullable: false)
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
                    price = table.Column<long>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    lon = table.Column<double>(nullable: false),
                    lat = table.Column<double>(nullable: false),
                    boxId = table.Column<int>(nullable: false),
                    registerDate = table.Column<string>(maxLength: 30, nullable: true),
                    charityId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_DischargeRoutes_charityId",
                table: "DischargeRoutes",
                column: "charityId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerCrowns_charityId",
                table: "FlowerCrowns",
                column: "charityId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerCrowns_flowerCrownTypeId",
                table: "FlowerCrowns",
                column: "flowerCrownTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Oprators_charityId",
                table: "Oprators",
                column: "charityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUss");

            migrationBuilder.DropTable(
                name: "AndroidVersions");

            migrationBuilder.DropTable(
                name: "BoxIncomes");

            migrationBuilder.DropTable(
                name: "ContactUss");

            migrationBuilder.DropTable(
                name: "FlowerCrowns");

            migrationBuilder.DropTable(
                name: "Oprators");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Stirs");

            migrationBuilder.DropTable(
                name: "Boxs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FlowerCrownTypes");

            migrationBuilder.DropTable(
                name: "DischargeRoutes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Charitys");
        }
    }
}
