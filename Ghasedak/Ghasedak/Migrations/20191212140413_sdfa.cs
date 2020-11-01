using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Areas_areaId",
                table: "Notices");

            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Categorys_categoryId",
                table: "Notices");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Provinces_provinceId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "FactorItems");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "NoticeImages");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "VisitNotices");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropIndex(
                name: "IX_Users_provinceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Notices_areaId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_categoryId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "cellphone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isCodeConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "oTPDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "provinceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "areaId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Notices");

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Users",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "cellphone",
                table: "Users",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isCodeConfirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "oTPDate",
                table: "Users",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "provinceId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "areaId",
                table: "Notices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Notices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    provinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Areas_Provinces_provinceId",
                        column: x => x.provinceId,
                        principalTable: "Provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    espacialPrice = table.Column<long>(nullable: false),
                    expirePrice = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    parentCategoryId = table.Column<int>(nullable: true),
                    registerPrice = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categorys_Categorys_parentCategoryId",
                        column: x => x.parentCategoryId,
                        principalTable: "Categorys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    createDatePersian = table.Column<string>(maxLength: 50, nullable: false),
                    factorKind = table.Column<int>(nullable: false),
                    noticeId = table.Column<int>(nullable: true),
                    state = table.Column<int>(nullable: false),
                    totalPrice = table.Column<long>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Factors_Notices_noticeId",
                        column: x => x.noticeId,
                        principalTable: "Notices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factors_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 5000, nullable: false),
                    title = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NoticeImages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    image = table.Column<string>(maxLength: 500, nullable: true),
                    noticeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_NoticeImages_Notices_noticeId",
                        column: x => x.noticeId,
                        principalTable: "Notices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    noticeId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Notices_noticeId",
                        column: x => x.noticeId,
                        principalTable: "Notices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitNotices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    countView = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(maxLength: 50, nullable: false),
                    noticeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitNotices", x => x.id);
                    table.ForeignKey(
                        name: "FK_VisitNotices_Notices_noticeId",
                        column: x => x.noticeId,
                        principalTable: "Notices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactorItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FactorId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    price = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_FactorItems_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactorItems_Notices_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Notices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_provinceId",
                table: "Users",
                column: "provinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_areaId",
                table: "Notices",
                column: "areaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_categoryId",
                table: "Notices",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_provinceId",
                table: "Areas",
                column: "provinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_parentCategoryId",
                table: "Categorys",
                column: "parentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactorItems_FactorId",
                table: "FactorItems",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_FactorItems_ProductId",
                table: "FactorItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_noticeId",
                table: "Factors",
                column: "noticeId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_userId",
                table: "Factors",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeImages_noticeId",
                table: "NoticeImages",
                column: "noticeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_noticeId",
                table: "UserFavorites",
                column: "noticeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_userId",
                table: "UserFavorites",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitNotices_noticeId",
                table: "VisitNotices",
                column: "noticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Areas_areaId",
                table: "Notices",
                column: "areaId",
                principalTable: "Areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Categorys_categoryId",
                table: "Notices",
                column: "categoryId",
                principalTable: "Categorys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Provinces_provinceId",
                table: "Users",
                column: "provinceId",
                principalTable: "Provinces",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
