using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_LibraryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "Description", "Genre", "IsAvailable", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling", "A young boy discovers he is a wizard and attends a magical school.", 2, true, 1997, "Harry Potter and the Sorcerer's Stone" },
                    { 2, "J.R.R. Tolkien", "A group of heroes embarks on a quest to destroy a powerful ring.", 2, true, 1954, "The Lord of the Rings: The Fellowship of the Ring" },
                    { 3, "J.D. Salinger", "A story about a young man's experiences in New York City after being expelled from school.", 5, false, 1951, "The Catcher in the Rye" },
                    { 4, "George Orwell", "A dystopian novel about a totalitarian regime that uses surveillance and mind control.", 6, true, 1949, "1984" },
                    { 5, "F. Scott Fitzgerald", "A novel about the American Dream, love, and wealth in the 1920s.", 5, false, 1925, "The Great Gatsby" },
                    { 6, "Herman Melville", "The tale of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.", 7, true, 1851, "Moby Dick" },
                    { 7, "Leo Tolstoy", "A historical epic set during the Napoleonic Wars in Russia.", 8, true, 1869, "War and Peace" },
                    { 8, "Dan Brown", "A symbologist uncovers a secret that could shake the foundations of Christianity.", 4, false, 2003, "The Da Vinci Code" },
                    { 9, "Suzanne Collins", "In a dystopian future, children are forced to compete in a deadly televised game.", 6, true, 2008, "The Hunger Games" },
                    { 10, "J.R.R. Tolkien", "A hobbit embarks on a journey to reclaim a treasure guarded by a dragon.", 2, true, 1937, "The Hobbit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
