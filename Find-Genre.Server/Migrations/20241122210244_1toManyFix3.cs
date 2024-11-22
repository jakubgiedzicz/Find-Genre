using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Genre.Server.Migrations
{
    /// <inheritdoc />
    public partial class _1toManyFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Genres_GenreId",
                table: "Tags",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
