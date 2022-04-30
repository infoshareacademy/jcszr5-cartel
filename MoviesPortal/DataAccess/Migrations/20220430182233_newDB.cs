using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreativePersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhotographyPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreativePersons", x => x.Id);
                });

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
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<int>(name: "Release Date", type: "int", maxLength: 2022, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "Nie dodano jeszcze żadnego opisu."),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForKids = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
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
                name: "Movie_CreativePerson",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_CreativePerson", x => new { x.CreativePersonId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Movie_CreativePerson_CreativePersons_CreativePersonId",
                        column: x => x.CreativePersonId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_CreativePerson_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Genre", x => x.Id);
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
                table: "CreativePersons",
                columns: new[] { "Id", "DateOfBirth", "Name", "PhotographyPath", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, null, "Sylvester", null, 1, "Stallone" },
                    { 2, null, "Ted", null, 0, "Kotcheff" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "action" },
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

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "IsForKids", "PosterPath", "Release Date", "Title", "TrailerUrl" },
                values: new object[] { 1, "John Rambo, były komandos, weteran wojny w Wietnamie, naraża się policjantom z pewnego miasteczka. Ci nie wiedzą, jak groźnym przeciwnikiem jest ten włóczęga.", false, "https://i.ebayimg.com/images/g/GB4AAOSwd1tdqF8D/s-l400.jpg", 1982, "Rambo", null });

            migrationBuilder.InsertData(
                table: "Movie_CreativePerson",
                columns: new[] { "CreativePersonId", "MovieId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Movie_CreativePerson",
                columns: new[] { "CreativePersonId", "MovieId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CreativePerson_MovieId",
                table: "Movie_CreativePerson",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Genre_GenreId",
                table: "Movie_Genre",
                column: "GenreId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Movie_CreativePerson");

            migrationBuilder.DropTable(
                name: "Movie_Genre");

            migrationBuilder.DropTable(
                name: "TvSeries_CreativePerson");

            migrationBuilder.DropTable(
                name: "TvSeries_Genre");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "CreativePersons");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "TvSeries");
        }
    }
}
