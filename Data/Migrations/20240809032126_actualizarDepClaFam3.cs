using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class actualizarDepClaFam3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clase",
                table: "Familias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdClase",
                table: "Familias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Departamento",
                table: "Clases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "Clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Familias_Clase",
                table: "Familias",
                column: "Clase");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_Departamento",
                table: "Clases",
                column: "Departamento");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Clase",
                table: "Familias");

            migrationBuilder.DropColumn(
                name: "IdClase",
                table: "Familias");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "Clases");
        }
    }
}
