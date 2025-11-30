using ClinicaParaiso.Application.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace ClinicaParaiso.Integration.Test.API.Integration.Services
{
    public class Paciente_POST : IClassFixture<ClinicaParaisoWebApplicationFactory>
    {
        private readonly ClinicaParaisoWebApplicationFactory app;

        public Paciente_POST(ClinicaParaisoWebApplicationFactory app)
        {
            this.app = app;
        }

        [Fact]
        public async Task Cadastra_paciente()
        {
            // Arrange
            using var client = app.CreateClient();

            var paciente = new PacienteDTO
            {
                Cpf = "45984044854",
                Email = "teste@ig.com",
                exists = false,
                Nome = "Teste Integration",
                Telefone = "11999999999",
                Sexo = "M"
            };


            //act
            var response = await client.PostAsJsonAsync("/api/Paciente", paciente);

            //assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
