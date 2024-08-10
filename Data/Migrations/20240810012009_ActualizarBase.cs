using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Clases_IdClase",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Departamentos_IdDepartamento",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Familias_IdFamilia",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Departamentos_Departamento",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Familias_Clases_Clase",
                table: "Familias");

            migrationBuilder.DropIndex(
                name: "IX_Familias_Clase",
                table: "Familias");

            migrationBuilder.DropIndex(
                name: "IX_Clases_Departamento",
                table: "Clases");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_IdClase",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_IdDepartamento",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_IdFamilia",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Clase",
                table: "Familias");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "Clase",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Familia",
                table: "Articulos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clase",
                table: "Familias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Departamento",
                table: "Clases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clase",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Departamento",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Familia",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Familias_Clase",
                table: "Familias",
                column: "Clase");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_Departamento",
                table: "Clases",
                column: "Departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdClase",
                table: "Articulos",
                column: "IdClase");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdDepartamento",
                table: "Articulos",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdFamilia",
                table: "Articulos",
                column: "IdFamilia");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Clases_IdClase",
                table: "Articulos",
                column: "IdClase",
                principalTable: "Clases",
                principalColumn: "IdClase");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Departamentos_IdDepartamento",
                table: "Articulos",
                column: "IdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Familias_IdFamilia",
                table: "Articulos",
                column: "IdFamilia",
                principalTable: "Familias",
                principalColumn: "IdFamilia");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Departamentos_Departamento",
                table: "Clases",
                column: "Departamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Familias_Clases_Clase",
                table: "Familias",
                column: "Clase",
                principalTable: "Clases",
                principalColumn: "IdClase");
        }
    }
}
