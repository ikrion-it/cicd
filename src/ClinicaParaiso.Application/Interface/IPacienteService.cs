using ClinicaParaiso.Application.DTOs;

namespace ClinicaParaiso.Application.Interface
{
    public interface IPacienteService
    {
        Task<PacienteDTO> AddPacienteAsync(PacienteDTO pacienteDTO);
        Task<PacienteDTO> GetPacienteByCpfAsync(string cpf);
        Task<List<PacienteDTO>> GetAllPacientesAsync(string cpf = "");
    }
}
