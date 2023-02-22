using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacanta.Migrations
{
    public partial class eiei : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrasID",
                table: "Luna",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Oras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeOras = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oras", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Luna_OrasID",
                table: "Luna",
                column: "OrasID");

            migrationBuilder.AddForeignKey(
                name: "FK_Luna_Oras_OrasID",
                table: "Luna",
                column: "OrasID",
                principalTable: "Oras",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luna_Oras_OrasID",
                table: "Luna");

            migrationBuilder.DropTable(
                name: "Oras");

            migrationBuilder.DropIndex(
                name: "IX_Luna_OrasID",
                table: "Luna");

            migrationBuilder.DropColumn(
                name: "OrasID",
                table: "Luna");
        }
    }
}
