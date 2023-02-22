using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacanta.Migrations
{
    public partial class dudu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaraID",
                table: "Luna",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaraDorita = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Luna_TaraID",
                table: "Luna",
                column: "TaraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Luna_Tara_TaraID",
                table: "Luna",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luna_Tara_TaraID",
                table: "Luna");

            migrationBuilder.DropTable(
                name: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Luna_TaraID",
                table: "Luna");

            migrationBuilder.DropColumn(
                name: "TaraID",
                table: "Luna");
        }
    }
}
