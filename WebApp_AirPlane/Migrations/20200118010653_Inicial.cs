using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_AirPlane.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirPlane",
                columns: table => new
                {
                    IdAviao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(nullable: true),
                    QtdTurbinas = table.Column<int>(nullable: false),
                    CapacPassageiros = table.Column<int>(nullable: false),
                    CapacCarga = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPlane", x => x.IdAviao);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    IdPassageiro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    IdAviao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.IdPassageiro);
                    table.ForeignKey(
                        name: "FK_Passengers_AirPlane_IdAviao",
                        column: x => x.IdAviao,
                        principalTable: "AirPlane",
                        principalColumn: "IdAviao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_IdAviao",
                table: "Passengers",
                column: "IdAviao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "AirPlane");
        }
    }
}
