using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaParaiso.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_nome_tabela_triagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_atendimentos_pacientes_PacienteId",
                table: "atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_triagems_atendimentos_AtendimentoId",
                table: "triagems");

            migrationBuilder.DropForeignKey(
                name: "FK_triagems_especialidades_EspecialidadeId",
                table: "triagems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pacientes",
                table: "pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_especialidades",
                table: "especialidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_atendimentos",
                table: "atendimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_triagems",
                table: "triagems");

            migrationBuilder.RenameTable(
                name: "pacientes",
                newName: "pacientes");

            migrationBuilder.RenameTable(
                name: "especialidades",
                newName: "especialidades");

            migrationBuilder.RenameTable(
                name: "atendimentos",
                newName: "atendimentos");

            migrationBuilder.RenameTable(
                name: "triagems",
                newName: "triagens");

            migrationBuilder.RenameIndex(
                name: "IX_atendimentos_PacienteId",
                table: "Atendimentos",
                newName: "IX_Atendimentos_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_triagems_EspecialidadeId",
                table: "Triagens",
                newName: "IX_Triagens_EspecialidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_triagems_AtendimentoId",
                table: "Triagens",
                newName: "IX_Triagens_AtendimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Atendimentos",
                table: "Atendimentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Triagens",
                table: "Triagens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Triagens_Atendimentos_AtendimentoId",
                table: "Triagens",
                column: "AtendimentoId",
                principalTable: "Atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Triagens_Especialidades_EspecialidadeId",
                table: "Triagens",
                column: "EspecialidadeId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Triagens_Atendimentos_AtendimentoId",
                table: "Triagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Triagens_Especialidades_EspecialidadeId",
                table: "Triagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Atendimentos",
                table: "Atendimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Triagens",
                table: "Triagens");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                newName: "pacientes");

            migrationBuilder.RenameTable(
                name: "Especialidades",
                newName: "especialidades");

            migrationBuilder.RenameTable(
                name: "Atendimentos",
                newName: "atendimentos");

            migrationBuilder.RenameTable(
                name: "Triagens",
                newName: "triagems");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_PacienteId",
                table: "atendimentos",
                newName: "IX_atendimentos_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Triagens_EspecialidadeId",
                table: "triagems",
                newName: "IX_triagems_EspecialidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Triagens_AtendimentoId",
                table: "triagems",
                newName: "IX_triagems_AtendimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pacientes",
                table: "pacientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_especialidades",
                table: "especialidades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_atendimentos",
                table: "atendimentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_triagems",
                table: "triagems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_atendimentos_pacientes_PacienteId",
                table: "atendimentos",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_triagems_atendimentos_AtendimentoId",
                table: "triagems",
                column: "AtendimentoId",
                principalTable: "atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_triagems_especialidades_EspecialidadeId",
                table: "triagems",
                column: "EspecialidadeId",
                principalTable: "especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
