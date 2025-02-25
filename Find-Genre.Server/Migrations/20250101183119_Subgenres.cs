using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Genre.Server.Migrations
{
    /// <inheritdoc />
    public partial class Subgenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentGenresId",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.CreateTable(
                name: "GenreGenre",
                columns: table => new
                {
                    ParentGenresId = table.Column<int>(type: "int", nullable: false),
                    SubgenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreGenre", x => new { x.ParentGenresId, x.SubgenresId });
                    table.ForeignKey(
                        name: "FK_GenreGenre_Genres_ParentGenresId",
                        column: x => x.ParentGenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreGenre_Genres_SubgenresId",
                        column: x => x.SubgenresId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreGenre_SubgenresId",
                table: "GenreGenre",
                column: "SubgenresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreGenre");

            migrationBuilder.DropColumn(
                name: "ParentGenresId",
                table: "Genres");
        }
    }
}
