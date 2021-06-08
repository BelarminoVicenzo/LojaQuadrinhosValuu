using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaQuadrinhos.DataAccess.Migrations
{
    public partial class RemoveUniqueConstraintOnQuadrinhoIdFromPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase",
                column: "QuadrinhoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase",
                column: "QuadrinhoId",
                unique: true);
        }
    }
}
