using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Genre.Server.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreTag_Genres_GenreId",
                table: "GenreTag");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GenreTag",
                newName: "GenresGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTag_Genres_GenresGenreId",
                table: "GenreTag",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreTag_Genres_GenresGenreId",
                table: "GenreTag");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "GenreTag",
                newName: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTag_Genres_GenreId",
                table: "GenreTag",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
