using Microsoft.EntityFrameworkCore.Migrations;

namespace DogsBredsW.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Altura = table.Column<string>(nullable: true),
                    EsperanzaDeVida = table.Column<string>(nullable: true),
                    Actividad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RazaCaracFisics",
                columns: table => new
                {
                    RazaId = table.Column<int>(nullable: false),
                    CaracFisicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RazaCaracFisics", x => new { x.CaracFisicId, x.RazaId });
                    table.ForeignKey(
                        name: "FK_RazaCaracFisics_Caracteristicas_CaracFisicId",
                        column: x => x.CaracFisicId,
                        principalTable: "Caracteristicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RazaCaracFisics_Razas_RazaId",
                        column: x => x.RazaId,
                        principalTable: "Razas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RazaHairTypes",
                columns: table => new
                {
                    RazaId = table.Column<int>(nullable: false),
                    HairTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RazaHairTypes", x => new { x.HairTypeId, x.RazaId });
                    table.ForeignKey(
                        name: "FK_RazaHairTypes_HairTypes_HairTypeId",
                        column: x => x.HairTypeId,
                        principalTable: "HairTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RazaHairTypes_Razas_RazaId",
                        column: x => x.RazaId,
                        principalTable: "Razas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RazaOrigenes",
                columns: table => new
                {
                    RazaId = table.Column<int>(nullable: false),
                    OriginId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RazaOrigenes", x => new { x.OriginId, x.RazaId });
                    table.ForeignKey(
                        name: "FK_RazaOrigenes_Origenes_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RazaOrigenes_Razas_RazaId",
                        column: x => x.RazaId,
                        principalTable: "Razas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RazaCaracFisics_RazaId",
                table: "RazaCaracFisics",
                column: "RazaId");

            migrationBuilder.CreateIndex(
                name: "IX_RazaHairTypes_RazaId",
                table: "RazaHairTypes",
                column: "RazaId");

            migrationBuilder.CreateIndex(
                name: "IX_RazaOrigenes_RazaId",
                table: "RazaOrigenes",
                column: "RazaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RazaCaracFisics");

            migrationBuilder.DropTable(
                name: "RazaHairTypes");

            migrationBuilder.DropTable(
                name: "RazaOrigenes");

            migrationBuilder.DropTable(
                name: "Caracteristicas");

            migrationBuilder.DropTable(
                name: "HairTypes");

            migrationBuilder.DropTable(
                name: "Origenes");

            migrationBuilder.DropTable(
                name: "Razas");
        }
    }
}
