using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class NewDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleCreativePerson");

            migrationBuilder.CreateTable(
                name: "Role_CreativeP_Movie",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreativePersonId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_CreativeP_Movie", x => new { x.CreativePersonId, x.RoleId });
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

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_MovieId",
                table: "Role_CreativeP_Movie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreativeP_Movie_RoleId",
                table: "Role_CreativeP_Movie",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role_CreativeP_Movie");

            migrationBuilder.CreateTable(
                name: "RoleCreativePerson",
                columns: table => new
                {
                    CreativePersonId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleCreativePerson", x => new { x.CreativePersonId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleCreativePerson_CreativePersons_CreativePersonId",
                        column: x => x.CreativePersonId,
                        principalTable: "CreativePersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleCreativePerson_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleCreativePerson_RoleId",
                table: "RoleCreativePerson",
                column: "RoleId");
        }
    }
}
