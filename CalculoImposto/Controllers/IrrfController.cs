using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IrrfController(IIrrfServico irrfServico) : ControllerBase
{
    private readonly IIrrfServico _irrfServico = irrfServico;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IrrfDto>>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10, [FromQuery] string busca = "")
    {
        var irrfList = await _irrfServico.PegarTodosIrrf(pagina, tamanho, busca);
        decimal totalIrrf = await _irrfServico.TotalIrrf();
        decimal totalPagina = (totalIrrf / tamanho) <= 0 ? 1 : Math.Ceiling(totalIrrf / tamanho);

        if (tamanho == 1)
        {
            totalPagina = totalIrrf;
        }

        if (!irrfList.Any())
        {
            return NotFound("Sem dados");
        }

        return Ok(new
        {
            totalIrrf,
            pagina,
            totalPagina,
            tamanho,
            irrfList
        });
    }
    [HttpGet("{id:int}", Name = "BuscarIrrf")]
    public async Task<ActionResult<IrrfDto>> PegarPorId(int id)
    {
        var irrf = await _irrfServico.PegarPorIdIrrf(id);

        if (irrf.Id <= 0)
        {
            return NotFound($"Sem dados para o Id {id} informado");
        }

        if (irrf is null)
        {
            return NotFound($"Sem dados para o Id {id} informado");
        }

        return Ok(irrf);
    }
    [HttpGet("Competencia/{strCompetencia}")]
    public async Task<ActionResult<IEnumerable<IrrfDto>>> PegarPorCompetencia(string strCompetencia)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        var irrfList = await _irrfServico.PegarPorCompetenciaIrrf(competencia);

        if (irrfList is null)
        {
            return NotFound($"Sem dados para o Competencia {competencia} informado");
        }

        return Ok(irrfList);
    }

    [HttpPost]
    public async Task<ActionResult<IrrfDto>> Post([FromBody] IrrfDto irrf)
    {
        if (irrf is not null)
        {
            try
            {
                await _irrfServico.CriarIrrf(irrf);
                return new CreatedAtRouteResult("BuscarIrrf", new { id = irrf.Id }, irrf);
            }
            catch (Exception)
            {
                throw;
            }
        }
        return BadRequest("Dados Invalidos");
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<IrrfDto>> Put(int id, [FromBody] IrrfDto irrf)
    {
        if (id != irrf.Id)
        {
            return BadRequest("Dados Inválidos");
        }
        if (irrf is null)
        {
            return BadRequest("Dados Inválidos");
        }

        await _irrfServico.AtualizarIrrf(irrf);
        return Ok(irrf);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IrrfDto>> Delete(int id)
    {
        var irrf = await _irrfServico.PegarPorIdIrrf(id);
        if (irrf is null)
        {
            return NotFound("Sem dados");
        }
        if (irrf.Id < 0)
        {
            return NotFound("Sem dados");
        }

        await _irrfServico.DeletarIrrf(id);
        return Ok(irrf);
    }
}
