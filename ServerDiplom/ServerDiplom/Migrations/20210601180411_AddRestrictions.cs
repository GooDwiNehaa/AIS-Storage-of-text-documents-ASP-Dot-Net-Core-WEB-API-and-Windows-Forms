using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerDiplom.Migrations
{
    public partial class AddRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLogin",
                table: "Users",
                column: "UserLogin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeUsers_Name",
                table: "TypeUsers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name",
                table: "Documents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserLogin",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TypeUsers_Name",
                table: "TypeUsers");

            migrationBuilder.DropIndex(
                name: "IX_Documents_Name",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");
        }
    }
}
