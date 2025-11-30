using ClinicaParaiso.Domain.Models;

namespace ClinicaParaiso.Persistence.Interface
{
    public interface IEspecialidadePersistence : IDefaultPersistence
    {
        Task<List<Especialidade>> GetAllEspecialidadeAsync();
    }
}
