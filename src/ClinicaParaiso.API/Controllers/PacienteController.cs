using ClinicaParaiso.API.Helpers;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaParaiso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            this.pacienteService = pacienteService;
        }

        [HttpPost()]
        public async Task<IActionResult> post(PacienteDTO pacienteDTO)
        {
            try
            {
                var paciente = await pacienteService.AddPacienteAsync(pacienteDTO);

                if (paciente == null)
                {
                    return BadRequest(new ApiResponse<PacienteDTO>(StatusCodes.Status400BadRequest, "Erro ao cadastrar paciente."));
                }

                var response = new ApiResponse<PacienteDTO>(paciente, StatusCodes.Status201Created, paciente.exists ? "Paciente já cadastrado." : "Paciente cadastrado com sucesso!");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<PacienteDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            try
            {
                var paciente = await pacienteService.GetPacienteByCpfAsync(cpf);

                if (paciente == null)
                {
                    return Ok(new ApiResponse<PacienteDTO>(StatusCodes.Status204NoContent, "Nenhum paciente foi encontrado."));
                }

                var response = new ApiResponse<PacienteDTO>(paciente, StatusCodes.Status200OK, "Dados do paciente carregado com sucesso!");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<PacienteDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpGet("GetallPacientes")]
        public async Task<IActionResult> GetallPacientes(string? cpf = "")
        {
            try
            {
                var pacientes = await pacienteService.GetAllPacientesAsync(cpf);

                if (pacientes.Count == 0)
                {
                    return Ok(new ApiResponse<PacienteDTO>(StatusCodes.Status204NoContent, "Nenhum paciente foi encontrado."));
                }

                var response = new ApiResponse<List<PacienteDTO>>(pacientes, StatusCodes.Status200OK, "Dados dos pacientes carregado com sucesso!");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<PacienteDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
