using AndreBrandaoCloudGamesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndreBrandaoCloudGamesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromocaoController : ControllerBase
    {
        private readonly PromocaoService _promocaoService;

        public PromocaoController(PromocaoService promocaoService)
        {
            _promocaoService = promocaoService;
        }

        [HttpPost("notificar")]
        [Authorize(Policy = "Admin")]
        public async Task<IResult> AplicaPromocaoJogos([FromBody] bool isPromotional)
        {
            try
            {
                await _promocaoService.AtualizaJogosAplicandoDesconto(isPromotional);
                return Results.Ok("Jogos atualizados com sucesso.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao atualizar Jogos");
            }

        }
    }
}

