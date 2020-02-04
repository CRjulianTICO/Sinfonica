using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinfonica.Web.Migrations
{
    public partial class ImagenConjuntos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Conjuntos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Conjuntos");

         
        }
    }
}
