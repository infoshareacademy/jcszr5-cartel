using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class TablesTvSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_CreativePersons_CreativePersons_CreativePersonId",
                table: "Movie_CreativePersons");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_CreativePersons_Movies_MovieId",
                table: "Movie_CreativePersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_CreativePersons",
                table: "Movie_CreativePersons");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movie_CreativePersons",
                newName: "Movie_CreativePerson");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_CreativePersons_MovieId",
                table: "Movie_CreativePerson",
                newName: "IX_Movie_CreativePerson_MovieId");

            migrationBuilder.AddColumn<string>(
                name: "PosterPath",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotographyPath",
                table: "CreativePersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_CreativePerson",
                table: "Movie_CreativePerson",
                columns: new[] { "CreativePersonId", "MovieId" });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "Nie dodano jeszcze żadnego opisu."),
                    Start_Year = table.Column<int>(type: "int", nullable: false),
                    End_Year = table.Column<int>(type: "int", nullable: false),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Genre",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Genre", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Movie_Genre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries_CreativePerson",
                columns: table => new
                {
                    TvSeriesId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries_CreativePerson", x => new { x.CreativePersonId, x.TvSeriesId });
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativePerson_CreativePersons_CreativePersonId",
                        column: x => x.CreativePersonId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativePerson_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries_Genre",
                columns: table => new
                {
                    TvSeriesId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries_Genre", x => new { x.GenreId, x.TvSeriesId });
                    table.ForeignKey(
                        name: "FK_TvSeries_Genre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeries_Genre_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "adventure" },
                    { 3, "animated" },
                    { 4, "comedy" },
                    { 5, "drama" },
                    { 6, "fantasy" },
                    { 7, "historical" },
                    { 8, "horror" },
                    { 9, "sciFi" },
                    { 10, "thriller" },
                    { 11, "western" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Genre_MovieId",
                table: "Movie_Genre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TvSeriesId",
                table: "Seasons",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_CreativePerson_TvSeriesId",
                table: "TvSeries_CreativePerson",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_Genre_TvSeriesId",
                table: "TvSeries_Genre",
                column: "TvSeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_CreativePerson_CreativePersons_CreativePersonId",
                table: "Movie_CreativePerson",
                column: "CreativePersonId",
                principalTable: "CreativePersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_CreativePerson_Movies_MovieId",
                table: "Movie_CreativePerson",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_CreativePerson_CreativePersons_CreativePersonId",
                table: "Movie_CreativePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_CreativePerson_Movies_MovieId",
                table: "Movie_CreativePerson");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Movie_Genre");

            migrationBuilder.DropTable(
                name: "TvSeries_CreativePerson");

            migrationBuilder.DropTable(
                name: "TvSeries_Genre");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "TvSeries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_CreativePerson",
                table: "Movie_CreativePerson");

            migrationBuilder.DropColumn(
                name: "PosterPath",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PhotographyPath",
                table: "CreativePersons");

            migrationBuilder.RenameTable(
                name: "Movie_CreativePerson",
                newName: "Movie_CreativePersons");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_CreativePerson_MovieId",
                table: "Movie_CreativePersons",
                newName: "IX_Movie_CreativePersons_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_CreativePersons",
                table: "Movie_CreativePersons",
                columns: new[] { "CreativePersonId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_CreativePersons_CreativePersons_CreativePersonId",
                table: "Movie_CreativePersons",
                column: "CreativePersonId",
                principalTable: "CreativePersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_CreativePersons_Movies_MovieId",
                table: "Movie_CreativePersons",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
