using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "BackgroundPoster",
                value: "https://c4.wallpaperflare.com/wallpaper/835/919/581/action-adventure-ark-fantasy-wallpaper-preview.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "BackgroundPoster",
                value: "https://vistapointe.net/images/raiders-of-the-lost-ark-6.jpg");
        }
    }
}
