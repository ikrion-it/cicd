using ClinicaParaiso.Application.DTOs;

namespace ClinicaParaiso.Application.Interface
{
    public interface IEspecialidadeService
    {
        Task<List<EspecialidadeDTO>> GetAllEspecialidadeAsync();
    }
}
