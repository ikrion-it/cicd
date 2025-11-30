using ClinicaParaiso.Domain.Models;

namespace ClinicaParaiso.Persistence.Interface
{
    public interface IAtendimentoPersistence : IDefaultPersistence
    {
        Task<Atendimento?> GetAtendimentoByIdAsync(int atendimentoId);
        Task<List<Atendimento>> GetAllAtendimentosAsync(string status = "");
    }
}
