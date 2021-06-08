using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaQuadrinhos.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AspNetUsers_Userid",
                table: "Purchase");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Purchase",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_Userid",
                table: "Purchase",
                newName: "IX_Purchase_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AspNetUsers_UserId",
                table: "Purchase",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AspNetUsers_UserId",
                table: "Purchase");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Purchase",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                newName: "IX_Purchase_Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AspNetUsers_Userid",
                table: "Purchase",
                column: "Userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
