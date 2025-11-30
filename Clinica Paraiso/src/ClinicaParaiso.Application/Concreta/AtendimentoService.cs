using AutoMapper;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Enum;
using ClinicaParaiso.Application.Helpers;
using ClinicaParaiso.Application.Interface;
using ClinicaParaiso.Domain.Models;
using ClinicaParaiso.Persistence.Interface;

namespace ClinicaParaiso.Application.Concreta
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IDefaultPersistence defaultPersistence;
        private readonly IAtendimentoPersistence atendimentoPersistence;
        private readonly IMapper mapper;

        public AtendimentoService(IDefaultPersistence defaultPersistence, IAtendimentoPersistence atendimentoPersistence ,IMapper mapper)
        {
            this.defaultPersistence = defaultPersistence;
            this.atendimentoPersistence = atendimentoPersistence;
            this.mapper = mapper;
        }

        public async Task<AtendimentoDTO?> AddAtendimentoAsync(AtendimentoDTO atendimentoDTO)
        {
            var atendimento = mapper.Map<Atendimento>(atendimentoDTO);
            atendimento.DataHoraChegada = DateTime.Now;
            atendimento.Status = Status.AtendimentoRealizado.ToString();
            defaultPersistence.Add(atendimento);

            if (await defaultPersistence.SaveChangesAsync())
            {
                atendimentoDTO.NumeroSequencial = atendimento.NumeroSequencial;
                return mapper.Map<AtendimentoDTO>(atendimento);
            }

            return null;
        }

        public async Task<bool> UpdateStatusAtendimentoAsync(int atendimentoId, string status)
        {
            var atendimento = await atendimentoPersistence.GetAtendimentoByIdAsync(atendimentoId);
            DomainException.When(atendimento == null, "Atendimento não encontrado.");

            atendimento.Status = status;
            defaultPersistence.Update(atendimento);

            return await defaultPersistence.SaveChangesAsync();
        }

        public async Task<List<AtendimentoDTO>> GetAllAtendimentosAsync(string status = "")
        {
            var atendimentos = await atendimentoPersistence.GetAllAtendimentosAsync(status);
            return mapper.Map<List<AtendimentoDTO>>(atendimentos);
        }
    }
}
