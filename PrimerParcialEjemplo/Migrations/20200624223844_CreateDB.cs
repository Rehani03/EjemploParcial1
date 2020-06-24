using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimerParcialEjemplo.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    empleadoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    sueldo = table.Column<decimal>(nullable: false),
                    ocupacion = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    cedula = table.Column<string>(nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.empleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    nivel = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    contraseña = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
