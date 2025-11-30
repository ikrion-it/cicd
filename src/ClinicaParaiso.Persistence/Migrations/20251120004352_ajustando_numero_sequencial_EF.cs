using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaParaiso.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajustando_numero_sequencial_EF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "NumeroSequencial");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroSequencial",
                table: "atendimentos",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR NumeroSequencial",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "NumeroSequencial");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroSequencial",
                table: "atendimentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR NumeroSequencial");
        }
    }
}
