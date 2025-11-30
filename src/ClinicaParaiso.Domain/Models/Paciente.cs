using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaParaiso.Domain.Models
{
    [Table("pacientes")]
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string? Telefone { get; set; }
        public string Sexo { get; set; }
        public string? Email { get; set; }

        public ICollection<Atendimento> Atendimentos { get; set; }
    }
}
