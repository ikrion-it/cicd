using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaParaiso.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajustando_relacao_tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_triagems_AtendimentoId",
                table: "triagems",
                column: "AtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_triagems_EspecialidadeId",
                table: "triagems",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_atendimentos_PacienteId",
                table: "atendimentos",
                column: "PacienteId");

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

            migrationBuilder.DropIndex(
                name: "IX_triagems_AtendimentoId",
                table: "triagems");

            migrationBuilder.DropIndex(
                name: "IX_triagems_EspecialidadeId",
                table: "triagems");

            migrationBuilder.DropIndex(
                name: "IX_atendimentos_PacienteId",
                table: "atendimentos");
        }
    }
}
