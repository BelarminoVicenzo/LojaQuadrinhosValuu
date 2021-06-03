using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaQuadrinhos.DataAccess.Migrations
{
    public partial class RenameColumnQuadrinhoId1ToQuadrinhoIdInPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Quadrinho_QuadrinhoId1",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_QuadrinhoGenre_QuadrinhoId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_QuadrinhoId1",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "QuadrinhoId1",
                table: "Purchase");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase",
                column: "QuadrinhoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Quadrinho_QuadrinhoId",
                table: "Purchase",
                column: "QuadrinhoId",
                principalTable: "Quadrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Quadrinho_QuadrinhoId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "QuadrinhoId1",
                table: "Purchase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_QuadrinhoId",
                table: "Purchase",
                column: "QuadrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_QuadrinhoId1",
                table: "Purchase",
                column: "QuadrinhoId1",
                unique: true,
                filter: "[QuadrinhoId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Quadrinho_QuadrinhoId1",
                table: "Purchase",
                column: "QuadrinhoId1",
                principalTable: "Quadrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_QuadrinhoGenre_QuadrinhoId",
                table: "Purchase",
                column: "QuadrinhoId",
                principalTable: "QuadrinhoGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
