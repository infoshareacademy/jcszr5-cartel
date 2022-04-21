using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SeedingDataTEST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CreativePersons",
                columns: new[] { "Id", "DateOfBirth", "Name", "Role", "Surname" },
                values: new object[] { 1, null, "Sylvester", 1, "Stallone" });

            migrationBuilder.InsertData(
                table: "CreativePersons",
                columns: new[] { "Id", "DateOfBirth", "Name", "Role", "Surname" },
                values: new object[] { 2, null, "Ted", 0, "Kotcheff" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "IsForKids", "Release Date", "Title" },
                values: new object[] { 1, "John Rambo, były komandos, weteran wojny w Wietnamie, naraża się policjantom z pewnego miasteczka. Ci nie wiedzą, jak groźnym przeciwnikiem jest ten włóczęga.", 0, false, 1982, "Rambo" });

            migrationBuilder.InsertData(
                table: "Movie_CreativePersons",
                columns: new[] { "CreativePersonId", "MovieId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Movie_CreativePersons",
                columns: new[] { "CreativePersonId", "MovieId" },
                values: new object[] { 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie_CreativePersons",
                keyColumns: new[] { "CreativePersonId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Movie_CreativePersons",
                keyColumns: new[] { "CreativePersonId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
