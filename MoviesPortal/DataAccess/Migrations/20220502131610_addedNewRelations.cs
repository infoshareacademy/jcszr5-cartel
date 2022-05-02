using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addedNewRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_CreativeP_Movie_Movies_MovieId",
                table: "Role_CreativeP_Movie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Role_CreativeP_Movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TvSeriesId",
                table: "Role_CreativeP_Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_TvSeriesId",
                table: "Role_CreativeP_Movie",
                column: "TvSeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_CreativeP_Movie_Movies_MovieId",
                table: "Role_CreativeP_Movie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_CreativeP_Movie_TvSeries_TvSeriesId",
                table: "Role_CreativeP_Movie",
                column: "TvSeriesId",
                principalTable: "TvSeries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_CreativeP_Movie_Movies_MovieId",
                table: "Role_CreativeP_Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_CreativeP_Movie_TvSeries_TvSeriesId",
                table: "Role_CreativeP_Movie");

            migrationBuilder.DropIndex(
                name: "IX_Role_CreativeP_Movie_TvSeriesId",
                table: "Role_CreativeP_Movie");

            migrationBuilder.DropColumn(
                name: "TvSeriesId",
                table: "Role_CreativeP_Movie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Role_CreativeP_Movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_CreativeP_Movie_Movies_MovieId",
                table: "Role_CreativeP_Movie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
