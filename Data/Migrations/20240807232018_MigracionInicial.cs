using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    IdClase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.IdClase);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    IdFamilia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.IdFamilia);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Sku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<int>(type: "int", nullable: true),
                    IdClase = table.Column<int>(type: "int", nullable: false),
                    Clase = table.Column<int>(type: "int", nullable: true),
                    IdFamilia = table.Column<int>(type: "int", nullable: false),
                    Familia = table.Column<int>(type: "int", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descontinuado = table.Column<bool>(type: "bit", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Sku);
                    table.ForeignKey(
                        name: "FK_Articulos_Clases_Clase",
                        column: x => x.Clase,
                        principalTable: "Clases",
                        principalColumn: "IdClase");
                    table.ForeignKey(
                        name: "FK_Articulos_Departamentos_Departamento",
                        column: x => x.Departamento,
                        principalTable: "Departamentos",
                        principalColumn: "IdDepartamento");
                    table.ForeignKey(
                        name: "FK_Articulos_Familias_Familia",
                        column: x => x.Familia,
                        principalTable: "Familias",
                        principalColumn: "IdFamilia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Clase",
                table: "Articulos",
                column: "Clase");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Departamento",
                table: "Articulos",
                column: "Departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Familia",
                table: "Articulos",
                column: "Familia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Familias");
        }
    }
}
