using AutoMapper;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Enum;
using ClinicaParaiso.Application.Interface;
using ClinicaParaiso.Domain.Models;
using ClinicaParaiso.Persistence.Interface;

namespace ClinicaParaiso.Application.Concreta
{
    public class TriagemService : ITriagemService
    {
        private readonly IDefaultPersistence defaultPersistence;
        private readonly IAtendimentoService atendimentoService;
        private readonly IMapper mapper;

        public TriagemService(IDefaultPersistence defaultPersistence, IAtendimentoService atendimentoService, IMapper mapper)
        {
            this.defaultPersistence = defaultPersistence;
            this.atendimentoService = atendimentoService;
            this.mapper = mapper;
        }

        public async Task<TriagemDTO?> AddTriagemAsync(TriagemDTO triagemDTO)
        {
            var triagem = mapper.Map<Triagem>(triagemDTO);
            defaultPersistence.Add(triagem);

            if (await defaultPersistence.SaveChangesAsync())
            {
                return (await atendimentoService.UpdateStatusAtendimentoAsync(triagem.AtendimentoId, Status.TriagemRealizada.ToString()))
                    ? mapper.Map<TriagemDTO>(triagem)
                    : null;
            }

            return null;
        }
    }
}
