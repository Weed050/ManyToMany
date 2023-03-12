using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "Library",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Library",
                columns: table => new
                {
                    BooksID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BooksID);
                });

            migrationBuilder.CreateTable(
                name: "BooksAndAuthors",
                schema: "Library",
                columns: table => new
                {
                    BooksID = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    AddingTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAndAuthors", x => new { x.AuthorID, x.BooksID });
                    table.ForeignKey(
                        name: "FK_BooksAndAuthors_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalSchema: "Library",
                        principalTable: "Author",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksAndAuthors_Books_BooksID",
                        column: x => x.BooksID,
                        principalSchema: "Library",
                        principalTable: "Books",
                        principalColumn: "BooksID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksAndAuthors_BooksID",
                schema: "Library",
                table: "BooksAndAuthors",
                column: "BooksID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksAndAuthors",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "Library");
        }
    }
}
