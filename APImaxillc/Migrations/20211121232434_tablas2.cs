using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APImaxillc.Migrations
{
    public partial class tablas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_Empleados_EmpleadoId",
                table: "Beneficiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiarios_Personas_PersonaId",
                table: "Beneficiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Personas_PersonaId",
                table: "Empleados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiarios",
                table: "Beneficiarios");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Persona");

            migrationBuilder.RenameTable(
                name: "Empleados",
                newName: "Empleado");

            migrationBuilder.RenameTable(
                name: "Beneficiarios",
                newName: "Beneficiario");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_PersonaId",
                table: "Empleado",
                newName: "IX_Empleado_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiarios_PersonaId",
                table: "Beneficiario",
                newName: "IX_Beneficiario_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiarios_EmpleadoId",
                table: "Beneficiario",
                newName: "IX_Beneficiario_EmpleadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado",
                column: "EmpleadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiario",
                table: "Beneficiario",
                column: "BeneficiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiario_Empleado_EmpleadoId",
                table: "Beneficiario",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiario_Persona_PersonaId",
                table: "Beneficiario",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Persona_PersonaId",
                table: "Empleado",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiario_Empleado_EmpleadoId",
                table: "Beneficiario");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiario_Persona_PersonaId",
                table: "Beneficiario");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Persona_PersonaId",
                table: "Empleado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiario",
                table: "Beneficiario");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Personas");

            migrationBuilder.RenameTable(
                name: "Empleado",
                newName: "Empleados");

            migrationBuilder.RenameTable(
                name: "Beneficiario",
                newName: "Beneficiarios");

            migrationBuilder.RenameIndex(
                name: "IX_Empleado_PersonaId",
                table: "Empleados",
                newName: "IX_Empleados_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiario_PersonaId",
                table: "Beneficiarios",
                newName: "IX_Beneficiarios_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiario_EmpleadoId",
                table: "Beneficiarios",
                newName: "IX_Beneficiarios_EmpleadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados",
                column: "EmpleadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiarios",
                table: "Beneficiarios",
                column: "BeneficiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_Empleados_EmpleadoId",
                table: "Beneficiarios",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiarios_Personas_PersonaId",
                table: "Beneficiarios",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Personas_PersonaId",
                table: "Empleados",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId");
        }
    }
}
