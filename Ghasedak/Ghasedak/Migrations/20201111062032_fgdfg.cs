using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghasedak.Migrations
{
    public partial class fgdfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoxIncomes_Users_userId",
                table: "BoxIncomes");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "BoxIncomes",
                newName: "opratorId");

            migrationBuilder.RenameIndex(
                name: "IX_BoxIncomes_userId",
                table: "BoxIncomes",
                newName: "IX_BoxIncomes_opratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoxIncomes_Oprators_opratorId",
                table: "BoxIncomes",
                column: "opratorId",
                principalTable: "Oprators",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoxIncomes_Oprators_opratorId",
                table: "BoxIncomes");

            migrationBuilder.RenameColumn(
                name: "opratorId",
                table: "BoxIncomes",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_BoxIncomes_opratorId",
                table: "BoxIncomes",
                newName: "IX_BoxIncomes_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoxIncomes_Users_userId",
                table: "BoxIncomes",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
