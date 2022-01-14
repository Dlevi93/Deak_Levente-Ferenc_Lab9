using Microsoft.EntityFrameworkCore.Migrations;

namespace Deak_Levente_Ferenc_Lab9.Migrations
{
    public partial class FixNamingIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Book_BookID",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Category_CategoryID",
                table: "BookCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "BookCategory",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "BookCategory",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryID",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_BookID",
                table: "BookCategory",
                newName: "IX_BookCategory_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Book_BookId",
                table: "BookCategory",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Category_CategoryId",
                table: "BookCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Book_BookId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Category_CategoryId",
                table: "BookCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BookCategory",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookCategory",
                newName: "BookID");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_BookId",
                table: "BookCategory",
                newName: "IX_BookCategory_BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Book_BookID",
                table: "BookCategory",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Category_CategoryID",
                table: "BookCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
