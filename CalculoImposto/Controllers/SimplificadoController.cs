using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimplificadoController(ISimplicadoServico simplicadoServico) : ControllerBase
    {
        readonly ISimplicadoServico _simplicadoServico = simplicadoServico;

        [HttpGet]
        public async Task<ActionResult<SimplificadoDto>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10, [FromQuery] string busca = "")
        {
            var simplificadoList = await _simplicadoServico.PegarTodosSimplificado(pagina, tamanho, busca);
            decimal totalSimplificado = await _simplicadoServico.TotalSimplificado();
            decimal totalPagina = (totalSimplificado / tamanho) <= 0 ? 1 : Math.Ceiling(totalSimplificado / tamanho);

            if (tamanho == 1)
            {
                totalPagina = totalSimplificado;
            }
            if (!simplificadoList.Any())
            {
                return NotFound("Sem dados");
            }

            return Ok(new
            {
                totalSimplificado,
                pagina,
                totalPagina,
                tamanho,
                simplificadoList
            });
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SimplificadoDto>> PegarPorId(int id)
        {
            var simplificado = await _simplicadoServico.PegarPorIdSimplificado(id);

            if (simplificado is not null)
            {
                return NotFound("Sem dados");
            }

            return Ok(simplificado);
        }
    }
}
