using ClinicaParaiso.API.Helpers;
using ClinicaParaiso.Application.DTOs;
using ClinicaParaiso.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaParaiso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriagemController : ControllerBase
    {
        private readonly ITriagemService triagemService;

        public TriagemController(ITriagemService triagemService)
        {
            this.triagemService = triagemService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TriagemDTO triagemDTO)
        {
            try
            {
                var triagem = await triagemService.AddTriagemAsync(triagemDTO);

                if (triagem == null)
                {
                    return BadRequest(new ApiResponse<TriagemDTO>(StatusCodes.Status400BadRequest, "Erro ao cadastrar triagem."));
                }

                return Ok(new ApiResponse<TriagemDTO>(triagem, StatusCodes.Status201Created, "Triagem cadastrada com sucesso!"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<TriagemDTO>(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
