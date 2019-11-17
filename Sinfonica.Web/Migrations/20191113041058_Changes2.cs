using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinfonica.Web.Migrations
{
    public partial class Changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PuestosId",
                table: "Empleados",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PuestosId",
                table: "Empleados",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
