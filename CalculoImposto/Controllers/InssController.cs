using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.Modelo.DTO.INSS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculoImposto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InssController(IINSSServico inssServico) : ControllerBase
    {
        readonly IINSSServico _inssServico = inssServico;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<INSSDto>>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10, [FromQuery] string busca = "")
        {
            var inssList = await _inssServico.PegarTodosInss(pagina, tamanho, busca);
            decimal totalInss = (decimal)await _inssServico.TotalInss(busca);
            decimal totalPagina = (totalInss / tamanho) <= 0 ? 1 : Math.Ceiling((totalInss / tamanho));

            if (tamanho == 1)
            {
                totalPagina = totalInss;
            }

            if (!inssList.Any())
            {
                return NotFound("Sem dados");
            }

            return Ok(new
            {
                totalInss,
                pagina,
                totalPagina,
                tamanho,
                inssList
            });
        }

        [HttpGet("Competencia/{strCompetencia:datetime}")]
        public async Task<ActionResult<IEnumerable<INSSDto>>> PegarTodosPorCompetencia(string strCompetencia)
        {
            DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
            var inssList = await _inssServico.PegarTodosPorCompetenciaInss(competencia);

            if (!inssList.Any())
            {
                return NotFound("Sem dados");
            }

            return Ok(inssList);
        }

        [HttpGet("Calculo/{strCompetencia:datetime}/{baseInss:decimal}")]
        public async Task<ActionResult<string>> Calculo(string strCompetencia, decimal baseInss)
        {
            DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
            var calculoInss = await _inssServico.CalculoInssProgressivo(competencia, baseInss);

            if (!calculoInss.Any())
            {
                return NotFound("Sem dados");
            }

            return Ok(calculoInss);
        }

        [HttpGet("Id/{id:int}", Name = "BuscarInss")]
        public async Task<ActionResult<INSSDto>> PegarPorId(int id)
        {
            var inss = await _inssServico.PegarPorIdInss(id);

            if (inss.Id <= 0)
            {
                return NotFound($"Sem dados para o Id {id} informado");
            }

            if (inss is not null)
            {
                return NotFound($"Sem dados para o Id {id} informado");
            }

            return Ok(inss);
        }

        [HttpPost]
        public async Task<ActionResult<INSSDto>> Post([FromBody] INSSDto inss)
        {
            if (inss is not null)
            {
                try
                {
                    await _inssServico.CriarInss(inss);
                    return new CreatedAtRouteResult("BuscarInss", new { id = inss.Id }, inss);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return BadRequest("Dados Invalidos");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<INSSDto>> Put(int id, [FromBody] INSSDto inss)
        {
            if (id != inss.Id)
            {
                return BadRequest("Dados Inválidos");
            }
            if (inss is null)
            {
                return BadRequest("Dados Inválidos");
            }

            await _inssServico.AtualizarInss(inss);
            return Ok(inss);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<INSSDto>> Delete(int id)
        {
            var inss = await _inssServico.PegarPorIdInss(id);
            if (inss is null)
            {
                return NotFound("Sem dados");
            }
            if (inss.Id < 0)
            {
                return NotFound("Sem dados");
            }

            await _inssServico.DeletarInss(id);
            return Ok(inss);
        }
    }
}
