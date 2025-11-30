using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaParaiso.Domain.Models
{
    [Table("triagens")]
    public class Triagem
    {
        public int Id { get; set; }
        public Atendimento Atendimento { get; set; }
        public int AtendimentoId { get; set; }
        public Especialidade Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
        public string? Sintomas { get; set; }
        public int PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}
