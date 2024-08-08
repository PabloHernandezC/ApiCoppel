using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class cambioArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Clases_Clase",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Departamentos_Departamento",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Familias_Familia",
                table: "Articulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_Clase",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_Departamento",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_Familia",
                table: "Articulos");

            migrationBuilder.DropColumn(
            name: "Sku",
            table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "IdArticulo",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "IdArticulo");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

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
                name: "IdArticulo",
                table: "Articulos");

            migrationBuilder.AlterColumn<int>(
                name: "Sku",
                table: "Articulos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "Sku");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Clases_Clase",
                table: "Articulos",
                column: "Clase",
                principalTable: "Clases",
                principalColumn: "IdClase");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Departamentos_Departamento",
                table: "Articulos",
                column: "Departamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Familias_Familia",
                table: "Articulos",
                column: "Familia",
                principalTable: "Familias",
                principalColumn: "IdFamilia");
        }
    }
}
