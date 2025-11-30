using ClinicaParaiso.API.Helpers;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaParaiso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService atendimentoService;

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            this.atendimentoService = atendimentoService;
        }

        [HttpPost()]
        public async Task<IActionResult> post(AtendimentoDTO atendimentoDTO)
        {
            try
            {
                var atendimento = await atendimentoService.AddAtendimentoAsync(atendimentoDTO);

                if (atendimento == null)
                {
                    return BadRequest(new ApiResponse<AtendimentoDTO>(StatusCodes.Status400BadRequest, "Erro ao cadastrar atendimento."));
                }

                return Ok(new ApiResponse<AtendimentoDTO>(atendimento, StatusCodes.Status201Created, "Atendimento realizado com sucesso!"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AtendimentoDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpPut("UpdateStatus/{atendimentoId}/{status}")]
        public async Task<IActionResult> UpdateStatus(int atendimentoId, string status)
        {
            try
            {
                var updated = await atendimentoService.UpdateStatusAtendimentoAsync(atendimentoId, status);

                if (!updated)
                {
                    return BadRequest(new ApiResponse<AtendimentoDTO>(StatusCodes.Status400BadRequest, "Erro ao tentar atualizar atendimento."));
                }

                return Ok(new ApiResponse<bool>(updated, StatusCodes.Status200OK, "Atendimento atualizado com sucesso!"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AtendimentoDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(string status = "")
        {
            try
            {
                var atendimentos = await atendimentoService.GetAllAtendimentosAsync(status);

                if (atendimentos.Count == 0)
                {
                    return Ok(new ApiResponse<AtendimentoDTO>(StatusCodes.Status204NoContent, "Nenhum atendimento em andamento."));
                }

                return Ok(new ApiResponse<List<AtendimentoDTO>>(atendimentos, StatusCodes.Status200OK, "Atendimentos carregados com sucesso!"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AtendimentoDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
