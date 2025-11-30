using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaParaiso.Domain.Models
{
    [Table("atendimentos")]
    public class Atendimento
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int NumeroSequencial { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public string Status { get; set; }

        public ICollection<Triagem> Triagens { get; set; }
    }
}
