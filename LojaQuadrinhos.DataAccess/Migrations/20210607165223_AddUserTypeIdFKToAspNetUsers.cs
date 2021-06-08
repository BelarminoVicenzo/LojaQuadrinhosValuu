using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaQuadrinhos.DataAccess.Migrations
{
    public partial class AddUserTypeIdFKToAspNetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserType_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserType_UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "AspNetUsers");
        }
    }
}
