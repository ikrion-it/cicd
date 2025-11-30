using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaParaiso.Domain.Models
{
    [Table("especialidades")]
    public class Especialidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Triagem> Triagens { get; set; }
    }
}
