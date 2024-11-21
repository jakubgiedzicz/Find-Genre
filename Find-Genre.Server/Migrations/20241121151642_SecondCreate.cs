using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Genre.Server.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreTag");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_GenreId",
                table: "Tags",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_GenreId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "GenreTag",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTag", x => new { x.GenreId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_GenreTag_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreTag_TagsId",
                table: "GenreTag",
                column: "TagsId");
        }
    }
}
