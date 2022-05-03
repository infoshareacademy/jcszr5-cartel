using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreativePersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhotographyPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<int>(name: "Release Date", type: "int", maxLength: 2022, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "Nie dodano jeszcze żadnego opisu."),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbRatio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForKids = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, defaultValue: "Nie dodano jeszcze żadnego opisu."),
                    Start_Year = table.Column<int>(type: "int", nullable: false),
                    End_Year = table.Column<int>(type: "int", nullable: false),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbRatio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie_CreativePerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_CreativePerson", x => x.Id);
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
                name: "Role_CreativeP_Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_CreativeP_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_CreativeP_Movie_CreativePersons_CreativePersonId",
                        column: x => x.CreativePersonId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_CreativeP_Movie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_CreativeP_Movie_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
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
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
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
                columns: new[] { "Id", "DateOfBirth", "Name", "PhotographyPath", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1946, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sylvester", "https://i.pinimg.com/originals/be/8f/3d/be8f3dfb132eb1b867379235d75a37b1.jpg", "Stallone" },
                    { 2, new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", "https://i.pinimg.com/originals/9d/73/d6/9d73d68e972ef3fd416f38c780e901ff.jpg", "Hardy" },
                    { 3, new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "https://i.pinimg.com/originals/13/62/b3/1362b30b97ed513559b4f28a5a3823f2.png", "Hemsworth" },
                    { 4, new DateTime(1976, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cillian", "https://i.pinimg.com/originals/01/aa/d4/01aad42f699f2bc8d0225047e7b23e03.jpg", "Murphy" },
                    { 5, new DateTime(1975, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taika", "https://i.pinimg.com/originals/74/e4/a5/74e4a59cb0e2a110166fd2eef714ad37.jpg", "Waititi" },
                    { 6, new DateTime(1931, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ted", "https://tce-live2.s3.amazonaws.com/media/media/74b70c1f-c4c4-4b77-9c6f-114cb1d62fdb.jpg", "Kotcheff" },
                    { 7, new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher", "https://i.pinimg.com/originals/6e/76/07/6e76076e9b218373ff054e57e6c307db.jpg", "Nolan" },
                    { 8, new DateTime(1969, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cate", "https://i.pinimg.com/originals/d5/23/75/d52375bb559b121f8221877db8b653a8.jpg", "Blanchett" }
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
                columns: new[] { "Id", "BackgroundPoster", "Description", "ImdbRatio", "IsForKids", "PosterPath", "Release Date", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "https://i.ytimg.com/vi/IAqLKlxY3Eo/maxresdefault.jpg", "John Rambo, były komandos, weteran wojny w Wietnamie, naraża się policjantom z pewnego miasteczka. Ci nie wiedzą, jak groźnym przeciwnikiem jest ten włóczęga.", "7.7", false, "https://i.ebayimg.com/images/g/GB4AAOSwd1tdqF8D/s-l400.jpg", 1982, "Rambo", "https://www.youtube.com/watch?v=IAqLKlxY3Eo" },
                    { 2, "https://c4.wallpaperflare.com/wallpaper/21/588/836/thor-ragnarok-4k-download-hd-for-desktop-wallpaper-preview.jpg", "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela.", "7.9", true, "https://preview.redd.it/hz8qlbfo4gr11.jpg?auto=webp&s=04d74ee2edec633bb566bb4801392f29fa5db299", 2017, "Thor: Ragnarok", "https://www.youtube.com/watch?v=v7MGUNV8MxU" },
                    { 3, "https://images7.alphacoders.com/855/thumb-1920-855790.jpg", "Allied soldiers from Belgium, the British Commonwealth and Empire, and France are surrounded by the German Army and evacuated during a fierce battle in World War II.", "7.8", false, "https://i.pinimg.com/originals/17/5c/e9/175ce930a9e1e42c4c0315d4933fc2d1.jpg", 2017, "Dunkirk", "https://www.youtube.com/watch?v=F-eMt3SrfFU" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Actor" },
                    { 2, "Director" }
                });

            migrationBuilder.InsertData(
                table: "Movie_CreativePerson",
                columns: new[] { "Id", "CreativePersonId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 6, 1 },
                    { 3, 3, 2 },
                    { 4, 5, 2 },
                    { 5, 8, 2 },
                    { 6, 2, 3 },
                    { 7, 4, 3 },
                    { 8, 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "Movie_Genre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 5, 1 },
                    { 3, 2, 2 },
                    { 4, 4, 2 },
                    { 5, 9, 2 },
                    { 6, 7, 3 },
                    { 7, 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Role_CreativeP_Movie",
                columns: new[] { "Id", "CreativePersonId", "MovieId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 6, 1, 2 },
                    { 3, 3, 2, 1 },
                    { 4, 5, 2, 1 },
                    { 5, 5, 2, 2 },
                    { 6, 8, 2, 1 },
                    { 7, 2, 3, 1 },
                    { 8, 4, 3, 1 },
                    { 9, 7, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CreativePerson_CreativePersonId",
                table: "Movie_CreativePerson",
                column: "CreativePersonId");

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
                name: "IX_Role_CreativeP_Movie_CreativePersonId",
                table: "Role_CreativeP_Movie",
                column: "CreativePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_MovieId",
                table: "Role_CreativeP_Movie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_RoleId",
                table: "Role_CreativeP_Movie",
                column: "RoleId");

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
                name: "Role_CreativeP_Movie");

            migrationBuilder.DropTable(
                name: "TvSeries_CreativePerson");

            migrationBuilder.DropTable(
                name: "TvSeries_Genre");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CreativePersons");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "TvSeries");
        }
    }
}
