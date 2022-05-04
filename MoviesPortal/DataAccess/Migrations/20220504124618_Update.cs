using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_CreativePersons_CreativePersonModelId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "CreativePersonModelRoleModel");

            migrationBuilder.DropTable(
                name: "CreativePersonModelTvSeriesModel");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CreativePersonModelId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CreativePersonModelId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "TvSeriesModelId",
                table: "CreativePersons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreativePersons_TvSeriesModelId",
                table: "CreativePersons",
                column: "TvSeriesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreativePersons_TvSeries_TvSeriesModelId",
                table: "CreativePersons",
                column: "TvSeriesModelId",
                principalTable: "TvSeries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreativePersons_TvSeries_TvSeriesModelId",
                table: "CreativePersons");

            migrationBuilder.DropIndex(
                name: "IX_CreativePersons_TvSeriesModelId",
                table: "CreativePersons");

            migrationBuilder.DropColumn(
                name: "TvSeriesModelId",
                table: "CreativePersons");

            migrationBuilder.AddColumn<int>(
                name: "CreativePersonModelId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreativePersonModelRoleModel",
                columns: table => new
                {
                    CreativePersonsId = table.Column<int>(type: "int", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreativePersonModelRoleModel", x => new { x.CreativePersonsId, x.RolesRoleId });
                    table.ForeignKey(
                        name: "FK_CreativePersonModelRoleModel_CreativePersons_CreativePersonsId",
                        column: x => x.CreativePersonsId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreativePersonModelRoleModel_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreativePersonModelTvSeriesModel",
                columns: table => new
                {
                    CreativePersonsId = table.Column<int>(type: "int", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreativePersonModelTvSeriesModel", x => new { x.CreativePersonsId, x.TvSeriesId });
                    table.ForeignKey(
                        name: "FK_CreativePersonModelTvSeriesModel_CreativePersons_CreativePersonsId",
                        column: x => x.CreativePersonsId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreativePersonModelTvSeriesModel_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CreativePersonModelId",
                table: "Movies",
                column: "CreativePersonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CreativePersonModelRoleModel_RolesRoleId",
                table: "CreativePersonModelRoleModel",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CreativePersonModelTvSeriesModel_TvSeriesId",
                table: "CreativePersonModelTvSeriesModel",
                column: "TvSeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_CreativePersons_CreativePersonModelId",
                table: "Movies",
                column: "CreativePersonModelId",
                principalTable: "CreativePersons",
                principalColumn: "Id");
        }
    }
}
