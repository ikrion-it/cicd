namespace ClinicaParaiso.Application.DTOs
{
    public class TriagemDTO
    {
        public int AtendimentoId { get; set; }
        public int EspecialidadeId { get; set; }
        public string? Sintomas { get; set; }
        public int PressaoArterial { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}
