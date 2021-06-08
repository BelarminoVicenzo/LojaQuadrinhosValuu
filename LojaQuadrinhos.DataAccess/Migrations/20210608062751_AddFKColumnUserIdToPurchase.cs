using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaQuadrinhos.DataAccess.Migrations
{
    public partial class AddFKColumnUserIdToPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Userid",
                table: "Purchase",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Userid",
                table: "Purchase",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AspNetUsers_Userid",
                table: "Purchase",
                column: "Userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AspNetUsers_Userid",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_Userid",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Purchase");
        }
    }
}
