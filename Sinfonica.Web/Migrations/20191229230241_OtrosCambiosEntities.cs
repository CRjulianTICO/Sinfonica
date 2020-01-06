using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sinfonica.Web.Migrations
{
    public partial class OtrosCambiosEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carrera",
                table: "Profesors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estudios",
                table: "Profesors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Profesors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Carrera",
                table: "Directors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estudios",
                table: "Directors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Directors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Directors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrera",
                table: "Profesors");

            migrationBuilder.DropColumn(
                name: "Estudios",
                table: "Profesors");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Profesors");

            migrationBuilder.DropColumn(
                name: "Carrera",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Estudios",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Directors");
        }
    }
}
