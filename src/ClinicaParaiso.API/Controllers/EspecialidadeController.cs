using ClinicaParaiso.API.Helpers;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaParaiso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService especialidadeService;

        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            this.especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var especialidades = await especialidadeService.GetAllEspecialidadeAsync();
                return Ok(new ApiResponse<List<EspecialidadeDTO>>(especialidades, StatusCodes.Status200OK, "Especialidades carregadas com sucesso!"));

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AtendimentoDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
