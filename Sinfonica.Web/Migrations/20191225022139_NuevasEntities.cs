using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinfonica.Web.Migrations
{
    public partial class NuevasEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Carnet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Encabezado = table.Column<string>(nullable: true),
                    Informacion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acontecers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Encabezado = table.Column<string>(nullable: true),
                    Informacion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Lugar = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    EstudiantesId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acontecers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acontecers_Estudiantes_EstudiantesId",
                        column: x => x.EstudiantesId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acontecers_EstudiantesId",
                table: "Acontecers",
                column: "EstudiantesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acontecers");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
