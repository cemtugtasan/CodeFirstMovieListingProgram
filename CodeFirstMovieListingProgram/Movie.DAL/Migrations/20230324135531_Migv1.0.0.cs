using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Migv100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PopularityRate = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmID);
                });

            migrationBuilder.CreateTable(
                name: "FilmCategories",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCategories", x => new { x.FilmID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_FilmCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCategories_Films_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Films",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Fantastic" },
                    { 4, "Science fiction" },
                    { 5, "Crime" },
                    { 6, "Drama" },
                    { 7, "Comedy" },
                    { 8, "Romantic" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "FilmID", "CategoryID", "FilmReleaseDate", "Name", "PopularityRate" },
                values: new object[,]
                {
                    { 1, 0, "2004", "Pirates of the Caribbean: The Curse of the Black Pearl", 8 },
                    { 2, 0, "1999", "The Matrix", 9 },
                    { 3, 0, "1972", "The Godfather", 10 },
                    { 4, 0, "2008", "YesMan", 6 },
                    { 5, 0, "2016", "Deadpool", 7 },
                    { 6, 0, "2005", "Pride&Prejudice", 5 }
                });

            migrationBuilder.InsertData(
                table: "FilmCategories",
                columns: new[] { "CategoryID", "FilmID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 7, 5 },
                    { 5, 6 },
                    { 6, 6 },
                    { 8, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_CategoryID",
                table: "FilmCategories",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
