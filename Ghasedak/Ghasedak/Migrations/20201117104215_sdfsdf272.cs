using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class sdfsdf272 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Oprators_opratorId",
                table: "UserActivities");

            migrationBuilder.AlterColumn<int>(
                name: "opratorId",
                table: "UserActivities",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Oprators_opratorId",
                table: "UserActivities",
                column: "opratorId",
                principalTable: "Oprators",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Oprators_opratorId",
                table: "UserActivities");

            migrationBuilder.AlterColumn<int>(
                name: "opratorId",
                table: "UserActivities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Oprators_opratorId",
                table: "UserActivities",
                column: "opratorId",
                principalTable: "Oprators",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
