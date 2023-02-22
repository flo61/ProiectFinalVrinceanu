using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacanta.Migrations
{
    public partial class fifi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VizitatID",
                table: "Luna",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vizitat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmVizitat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vizitat", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Luna_VizitatID",
                table: "Luna",
                column: "VizitatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Luna_Vizitat_VizitatID",
                table: "Luna",
                column: "VizitatID",
                principalTable: "Vizitat",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luna_Vizitat_VizitatID",
                table: "Luna");

            migrationBuilder.DropTable(
                name: "Vizitat");

            migrationBuilder.DropIndex(
                name: "IX_Luna_VizitatID",
                table: "Luna");

            migrationBuilder.DropColumn(
                name: "VizitatID",
                table: "Luna");
        }
    }
}
