using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateForTvSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TvSeries_CreativeP_Role",
                columns: table => new
                {
                    TvSeriesId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries_CreativeP_Role", x => new { x.TvSeriesId, x.CreativePersonId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativeP_Role_CreativePersons_CreativePersonId",
                        column: x => x.CreativePersonId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativeP_Role_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvSeries_CreativeP_Role_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_CreativeP_Role_CreativePersonId",
                table: "TvSeries_CreativeP_Role",
                column: "CreativePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TvSeries_CreativeP_Role_RoleId",
                table: "TvSeries_CreativeP_Role",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TvSeries_CreativeP_Role");

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
    }
}
