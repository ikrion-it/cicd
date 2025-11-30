using AutoMapper;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Domain.Models;

namespace ClinicaParaiso.Application.Helpers
{
    public class ClinicaParaisoProfile : Profile
    {
        public ClinicaParaisoProfile()
        {
            CreateMap<PacienteDTO, Paciente>().ReverseMap().ForMember(dest => dest.IdExterno, opt => opt.MapFrom(src => src.Id));
            CreateMap<AtendimentoDTO, Atendimento>().ReverseMap().ForMember(dest => dest.IdExterno, opt => opt.MapFrom(src => src.Id));
            CreateMap<EspecialidadeDTO, Especialidade>().ReverseMap();
            CreateMap<TriagemDTO, Triagem>().ReverseMap();
        }
    }
}
