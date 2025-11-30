using ClinicaParaiso.Application.DTOs;

namespace ClinicaParaiso.Application.Interface
{
    public interface IAtendimentoService
    {
        Task<AtendimentoDTO> AddAtendimentoAsync(AtendimentoDTO atendimentoDTO);
        Task<bool> UpdateStatusAtendimentoAsync(int atendimentoId, string status);
        Task<List<AtendimentoDTO>> GetAllAtendimentosAsync(string status = "");
    }
}
