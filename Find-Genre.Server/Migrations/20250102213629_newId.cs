using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Genre.Server.Migrations
{
    /// <inheritdoc />
    public partial class newId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreGenre_Genres_ParentGenresId",
                table: "GenreGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGenre_Genres_SubgenresId",
                table: "GenreGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreTag_Genres_GenresId",
                table: "GenreTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreTag_Tags_TagsId",
                table: "GenreTag");

            migrationBuilder.DropColumn(
                name: "ParentGenresId",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "GenreTag",
                newName: "TagsTagId");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "GenreTag",
                newName: "GenresGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreTag_TagsId",
                table: "GenreTag",
                newName: "IX_GenreTag_TagsTagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "SubgenresId",
                table: "GenreGenre",
                newName: "SubgenresGenreId");

            migrationBuilder.RenameColumn(
                name: "ParentGenresId",
                table: "GenreGenre",
                newName: "ParentGenresGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreGenre_SubgenresId",
                table: "GenreGenre",
                newName: "IX_GenreGenre_SubgenresGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGenre_Genres_ParentGenresGenreId",
                table: "GenreGenre",
                column: "ParentGenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGenre_Genres_SubgenresGenreId",
                table: "GenreGenre",
                column: "SubgenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTag_Genres_GenresGenreId",
                table: "GenreTag",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTag_Tags_TagsTagId",
                table: "GenreTag",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreGenre_Genres_ParentGenresGenreId",
                table: "GenreGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreGenre_Genres_SubgenresGenreId",
                table: "GenreGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreTag_Genres_GenresGenreId",
                table: "GenreTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreTag_Tags_TagsTagId",
                table: "GenreTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagsTagId",
                table: "GenreTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "GenreTag",
                newName: "GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreTag_TagsTagId",
                table: "GenreTag",
                newName: "IX_GenreTag_TagsId");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubgenresGenreId",
                table: "GenreGenre",
                newName: "SubgenresId");

            migrationBuilder.RenameColumn(
                name: "ParentGenresGenreId",
                table: "GenreGenre",
                newName: "ParentGenresId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreGenre_SubgenresGenreId",
                table: "GenreGenre",
                newName: "IX_GenreGenre_SubgenresId");

            migrationBuilder.AddColumn<string>(
                name: "ParentGenresId",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGenre_Genres_ParentGenresId",
                table: "GenreGenre",
                column: "ParentGenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreGenre_Genres_SubgenresId",
                table: "GenreGenre",
                column: "SubgenresId",
                principalTable: "Genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTag_Genres_GenresId",
                table: "GenreTag",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTag_Tags_TagsId",
                table: "GenreTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
