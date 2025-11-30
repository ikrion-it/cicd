using AutoMapper;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Helpers;
using ClinicaParaiso.Application.Interface;
using ClinicaParaiso.Persistence.Interface;

namespace ClinicaParaiso.Application.Concreta
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadePersistence especialidadePersistence;
        private readonly IMapper mapper;

        public EspecialidadeService(IEspecialidadePersistence especialidadePersistence, IMapper mapper)
        {
            this.especialidadePersistence = especialidadePersistence;
            this.mapper = mapper;
        }

        public async Task<List<EspecialidadeDTO>> GetAllEspecialidadeAsync()
        {
            var especialidades = await especialidadePersistence.GetAllEspecialidadeAsync();
            DomainException.When(especialidades.Count == 0, "Nenhuma especialidade encontrada.");

            return mapper.Map<List<EspecialidadeDTO>>(especialidades);
        }
    }
}
