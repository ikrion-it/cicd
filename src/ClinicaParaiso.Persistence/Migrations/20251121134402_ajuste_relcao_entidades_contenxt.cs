using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaParaiso.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_relcao_entidades_contenxt : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_atendimentos_pacientes_PacienteId",
                table: "atendimentos",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_triagems_atendimentos_AtendimentoId",
                table: "triagems",
                column: "AtendimentoId",
                principalTable: "atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_triagems_especialidades_EspecialidadeId",
                table: "triagems",
                column: "EspecialidadeId",
                principalTable: "especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
