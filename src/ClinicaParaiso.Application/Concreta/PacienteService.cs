using AutoMapper;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Interface;
using ClinicaParaiso.Domain.Models;
using ClinicaParaiso.Persistence.Interface;

namespace ClinicaParaiso.Application.Concreta
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacientePersistence pacientePersistence;
        private readonly IMapper mapper;

        public PacienteService(IPacientePersistence pacientePersistence, IMapper mapper)
        {
            this.pacientePersistence = pacientePersistence;
            this.mapper = mapper;
        }

        public async Task<PacienteDTO?> AddPacienteAsync(PacienteDTO pacienteDTO)
        {
            var paciente = await pacientePersistence.GetPacienteByCpfAsync(pacienteDTO.Cpf);

            if (paciente == null)
            {
                paciente = mapper.Map<Paciente>(pacienteDTO);
                pacientePersistence.Add(paciente);

                if (await pacientePersistence.SaveChangesAsync())
                {
                    pacienteDTO.IdExterno = paciente.Id;
                    return pacienteDTO;
                }

                return null;
            }

            pacienteDTO.exists = true;
            pacienteDTO.IdExterno = paciente.Id;
            return pacienteDTO;
        }

        public async Task<List<PacienteDTO>> GetAllPacientesAsync(string cpf = "")
        {
            var pacientes = await pacientePersistence.GetallPacientesAsync(cpf);
            return mapper.Map<List<PacienteDTO>>(pacientes);
        }

        public async Task<PacienteDTO> GetPacienteByCpfAsync(string cpf)
        {
            var paciente = await pacientePersistence.GetPacienteByCpfAsync(cpf, true);
            return mapper.Map<PacienteDTO>(paciente);
        }
    }
}
