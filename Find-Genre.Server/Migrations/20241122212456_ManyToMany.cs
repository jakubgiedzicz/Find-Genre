using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Genre.Server.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_GenreId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "GenreTag",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    TagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTag", x => new { x.GenreId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_GenreTag_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreTag_TagsTagId",
                table: "GenreTag",
                column: "TagsTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreTag");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_GenreId",
                table: "Tags",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId");
        }
    }
}
