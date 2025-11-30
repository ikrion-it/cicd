using ClinicaParaiso.Application.DTOs;

namespace ClinicaParaiso.Application.Interface
{
    public interface ITriagemService
    {
        Task<TriagemDTO?> AddTriagemAsync(TriagemDTO triagemDTO);
    }
}
