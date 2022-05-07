using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "BackgroundPoster",
                value: "https://blog.hdwallsource.com/wp-content/uploads/2018/05/avengers-infinity-war-thanos-wallpaper-63589-65679-hd-wallpapers.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "BackgroundPoster",
                value: "https://images7.alphacoders.com/100/1004126.png");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BackgroundPoster", "PosterPath" },
                values: new object[] { "https://vistapointe.net/images/raiders-of-the-lost-ark-6.jpg", "https://i.pinimg.com/originals/f2/87/36/f28736d093de503e783c4bf247230cb3.jpg" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BackgroundPoster", "PosterPath" },
                values: new object[] { "https://vistapointe.net/images/indiana-jones-and-the-last-crusade-2.jpg", "https://static.squarespace.com/static/51b3dc8ee4b051b96ceb10de/51ce6099e4b0d911b4489b79/51ce61e9e4b0d911b44a5773/1328897573177/1000w/temple-of-doom-minimalist-print.jpg" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "BackgroundPoster",
                value: "https://images.hdqwalls.com/wallpapers/the-dark-knight-aftermath-4k-yk.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "BackgroundPoster",
                value: "https://cdnb.artstation.com/p/assets/images/images/010/440/503/large/lee-j-p-1.jpg?1524459988");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "BackgroundPoster",
                value: "https://s2.best-wallpaper.net/wallpaper/2880x1800/1805/Captain-America-Civil-War-art-picture_2880x1800.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BackgroundPoster", "PosterPath" },
                values: new object[] { "https://www.deviantart.com/spirit--of-adventure/art/Raiders-of-the-Lost-Ark-Wallpaper-852520409", "https://cdn.shopify.com/s/files/1/1057/4964/products/Raiders-of-the-Lost-Ark-Vintage-Movie-Poster-Original-1-Sheet-27x41-7665.jpg?v=1643864480" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BackgroundPoster", "PosterPath" },
                values: new object[] { "https://www.deviantart.com/spirit--of-adventure/art/The-Last-Crusade-Wallpaper-852714249", "https://m.media-amazon.com/images/I/91uXYJym1dL._AC_SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "BackgroundPoster",
                value: "https://c4.wallpaperflare.com/wallpaper/475/754/518/joker-street-the-dark-knight-clown-mask-wallpaper-preview.jpg");
        }
    }
}
