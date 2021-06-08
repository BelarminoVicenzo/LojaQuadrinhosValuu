using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaQuadrinhos.DataAccess.Migrations
{
    public partial class removedCustomerIdFKFromPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PurchaseId",
                table: "Customer",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Purchase_PurchaseId",
                table: "Customer",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Purchase_PurchaseId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PurchaseId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Customer_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
