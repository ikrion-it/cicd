using ClinicaParaiso.Domain.Models;

namespace ClinicaParaiso.Persistence.Interface
{
    public interface IPacientePersistence : IDefaultPersistence
    {
        Task<Paciente> GetPacienteByCpfAsync(string cpf, bool showLastAtendimento = false);
        Task<List<Paciente>> GetallPacientesAsync(string cpf = "");
    }
}
