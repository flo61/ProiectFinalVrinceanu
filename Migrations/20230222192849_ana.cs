using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacanta.Migrations
{
    public partial class ana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Luna",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persoane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Suveniruri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luna", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Luna");
        }
    }
}
