using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.Modelo.DTO.INSS;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InssController(IInssServico inssServico) : ControllerBase
{
    private readonly IInssServico _inssServico = inssServico;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InssDto>>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
    {
        var inssList = await _inssServico.PegarTodos(pagina, tamanho);
        decimal totalInss = await _inssServico.TotalInss("");
        decimal totalPagina = (totalInss / tamanho) <= 0 ? 1 : Math.Ceiling(totalInss / tamanho);

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
    [HttpGet("Competencia/{strCompetencia}")]
    public async Task<ActionResult<IEnumerable<InssDto>>> PegarTodosPorCompetencia(string strCompetencia)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        var inssList = await _inssServico.PegarTodosPorCompetenciaInss(competencia);

        if (!inssList.Any())
        {
            return NotFound("Sem dados");
        }

        return Ok(inssList);
    }
    [HttpGet("{id:int}", Name = "BuscarInss")]
    public async Task<ActionResult<InssDto>> PegarPorId(int id)
    {
        var inss = await _inssServico.PegarPorId(id);

        if (inss.Id <= 0)
        {
            return NotFound($"Sem dados para o Id {id} informado");
        }

        if (inss is null)
        {
            return NotFound($"Sem dados para o Id {id} informado");
        }

        return Ok(inss);
    }
    [HttpPost]
    public async Task<ActionResult<InssDto>> Post([FromBody] InssDto inss)
    {
        if (inss is not null)
        {
            try
            {
                await _inssServico.Criar(inss);
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
    public async Task<ActionResult<InssDto>> Put(int id, [FromBody] InssDto inss)
    {
        if (id != inss.Id)
        {
            return BadRequest("Dados Inválidos");
        }
        if (inss is null)
        {
            return BadRequest("Dados Inválidos");
        }

        await _inssServico.Atualizar(inss);
        return Ok(inss);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<InssDto>> Delete(int id)
    {
        var inss = await _inssServico.PegarPorId(id);
        if (inss is null)
        {
            return NotFound("Sem dados");
        }
        if (inss.Id < 0)
        {
            return NotFound("Sem dados");
        }

        await _inssServico.Deletar(id);
        return Ok(inss);
    }
}
