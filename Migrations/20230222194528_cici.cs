using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacanta.Migrations
{
    public partial class cici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContinentID",
                table: "Luna",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireContinent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Luna_ContinentID",
                table: "Luna",
                column: "ContinentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Luna_Continent_ContinentID",
                table: "Luna",
                column: "ContinentID",
                principalTable: "Continent",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luna_Continent_ContinentID",
                table: "Luna");

            migrationBuilder.DropTable(
                name: "Continent");

            migrationBuilder.DropIndex(
                name: "IX_Luna_ContinentID",
                table: "Luna");

            migrationBuilder.DropColumn(
                name: "ContinentID",
                table: "Luna");
        }
    }
}
