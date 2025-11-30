using System.ComponentModel.DataAnnotations;

namespace ClinicaParaiso.Application.DTOs
{
    public class PacienteDTO
    {
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF do paciente não pode ser vazio.")]
        public string Cpf { get; set; }
        public string? Telefone { get; set; }
        public string Sexo { get; set; }
        public string? Email { get; set; }
        public int? IdExterno { get; set; }

        public bool exists { get; set; } = false;
    }
}
