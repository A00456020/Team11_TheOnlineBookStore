using Microsoft.EntityFrameworkCore.Migrations;

namespace TheOnlineBookStore.Migrations
{
    public partial class authors_books_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsAndBooks_Authors_BookID",
                table: "AuthorsAndBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsAndBooks_Books_AuthorID",
                table: "AuthorsAndBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorsAndBooks",
                table: "AuthorsAndBooks");

            migrationBuilder.RenameTable(
                name: "AuthorsAndBooks",
                newName: "Authors_Books");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorsAndBooks_BookID",
                table: "Authors_Books",
                newName: "IX_Authors_Books_BookID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors_Books",
                table: "Authors_Books",
                columns: new[] { "AuthorID", "BookID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_Authors_BookID",
                table: "Authors_Books",
                column: "BookID",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_Books_AuthorID",
                table: "Authors_Books",
                column: "AuthorID",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_Authors_BookID",
                table: "Authors_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_Books_AuthorID",
                table: "Authors_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors_Books",
                table: "Authors_Books");

            migrationBuilder.RenameTable(
                name: "Authors_Books",
                newName: "AuthorsAndBooks");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_Books_BookID",
                table: "AuthorsAndBooks",
                newName: "IX_AuthorsAndBooks_BookID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorsAndBooks",
                table: "AuthorsAndBooks",
                columns: new[] { "AuthorID", "BookID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsAndBooks_Authors_BookID",
                table: "AuthorsAndBooks",
                column: "BookID",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsAndBooks_Books_AuthorID",
                table: "AuthorsAndBooks",
                column: "AuthorID",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
