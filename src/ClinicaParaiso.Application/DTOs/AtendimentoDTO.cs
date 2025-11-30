namespace ClinicaParaiso.Application.DTOs
{
    public class AtendimentoDTO
    {
        public int PacienteId { get; set; }
        public int? NumeroSequencial { get; set; }
        public DateTime? DataHoraChegada { get; set; }
        public string? Status { get; set; }
        public int? IdExterno { get; set; }
        public PacienteDTO? Paciente { get; set; }
    }
}
