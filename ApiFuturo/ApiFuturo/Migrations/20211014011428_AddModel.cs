using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiFuturo.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Futuros",
                columns: table => new
                {
                    FuturId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Palabras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Futuros", x => x.FuturId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Futuros");
        }
    }
}
