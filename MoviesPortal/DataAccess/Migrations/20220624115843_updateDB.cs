using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/a9sa6ERZCpplbPEO7OMWE763CLD.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/ebSnODDg9lbsMIaWg2uAbjn7TO5.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/7WsyChQLEftFiDOVTGkv3hFpyyt.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/rAGiXaUfPzY7CDEyNKUofk3Kw2e.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/6FfCtAuVAW8XJjZ7eWeLibRLWTw.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/2l05cFWJacyIsTpsqSgH0wQXe4V.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/1kAbMLKVJz7LGjs8nnp259tffry.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/ceG9VzoRAVGwivFU403Wc3AHRys.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/sizg1AU8f8JDZX4QIgE4pjUMBvx.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/mS4EvhsrT0SQZOlWrQEzWI5KiUa.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/vGYJRor3pCyjbaCpJKC39MpJhIT.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/yk4J4aewWYNiBhD49WD7UaBBn37.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/a26cQPRhJPX6GbWfQbvZdrrp9j9.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/sj8dIprCrqeVdikCsWODyjDjhST.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/jXbqfVHmvCikyTw2Lf5OhKyt9Ym.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/kqERBMBQ5L45VmtDiuWmZiAhgzg.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18,
                column: "PosterPath",
                value: "https://image.tmdb.org/t/p/original/A7CzMZBitf00BAtb1kJa50pWPgV.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2015/03/gabz_firstblood700.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2019/10/duperray_dunkirk.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2018/05/bergeron_infinity.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2016/06/walker_civilwar.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2021/12/AlexHovey_NewHope.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2021/12/AlexHovey_Empire.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2021/12/AlexHovey_Jedi.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "PosterPath",
                value: "https://i.pinimg.com/originals/f2/87/36/f28736d093de503e783c4bf247230cb3.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "PosterPath",
                value: "https://static.squarespace.com/static/51b3dc8ee4b051b96ceb10de/51ce6099e4b0d911b4489b79/51ce61e9e4b0d911b44a5773/1328897573177/1000w/temple-of-doom-minimalist-print.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2020/05/daus_interstellar.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "PosterPath",
                value: "https://cdn.shopify.com/s/files/1/0071/5192/products/Screen_Shot_2017-12-06_at_17.45.00_1024x1024.png?v=1512583353");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2018/05/AMP_Her.png");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "PosterPath",
                value: "https://i.pinimg.com/736x/2e/0c/ee/2e0ceec2f8bc16b562a8cec2d4d1b86f.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "PosterPath",
                value: "https://i.pinimg.com/originals/9a/6b/92/9a6b929842b8affe801112608266087b.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "PosterPath",
                value: "https://i.pinimg.com/originals/df/1b/a2/df1ba2a4e5d4f8a99a323261df3be7ee.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17,
                column: "PosterPath",
                value: "https://64.media.tumblr.com/0d4d9f32780322b9c0fe71857904d6cf/11a1f8baccb49d40-8b/s540x810/2b46dc8aaa865250e899a5fb42eedf47de4d6823.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18,
                column: "PosterPath",
                value: "https://alternativemovieposters.com/wp-content/uploads/2019/09/knotek_drstrange.jpg");
        }
    }
}
