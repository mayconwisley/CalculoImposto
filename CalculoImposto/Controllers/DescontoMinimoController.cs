using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DescontoMinimoController(IDescontoMinimoServico descontoMinimo) : ControllerBase
{
    private readonly IDescontoMinimoServico _descontoMinimo = descontoMinimo;
    [HttpGet]
    public async Task<ActionResult<DescontoMinimoDto>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10, [FromQuery] string busca = "")
    {
        var descontoMinimoList = await _descontoMinimo.PegarTodosDescontoMinimo(pagina, tamanho, busca);
        decimal totalDescontoMinimo = await _descontoMinimo.TotalDescontoMinimo();
        decimal totalPagina = (totalDescontoMinimo / tamanho) <= 0 ? 1 : Math.Ceiling(totalDescontoMinimo / tamanho);

        if (tamanho == 1)
        {
            totalPagina = totalDescontoMinimo;
        }
        if (!descontoMinimoList.Any())
        {
            return NotFound("Sem dados");
        }

        return Ok(new
        {
            totalDescontoMinimo,
            pagina,
            totalPagina,
            tamanho,
            descontoMinimoList
        });
    }
    [HttpGet("{id:int}", Name = "BuscarDescontoMinimo")]
    public async Task<ActionResult<DescontoMinimoDto>> PegarPorId(int id)
    {
        var descontoMinimo = await _descontoMinimo.PegarPorIdDescontoMinimo(id);

        if (descontoMinimo is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(descontoMinimo);
    }
    [HttpGet("Competencia/{strCompetencia}")]
    public async Task<ActionResult<IEnumerable<DescontoMinimoDto>>> PegarPorCompetenciaDescontoMinimo(string strCompetencia)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        try
        {
            var descontoMinimoList = await _descontoMinimo.PegarPorCompetenciaDescontoMinimo(competencia);
            if (descontoMinimoList is null)
            {
                return NotFound();
            }

            return Ok(descontoMinimoList);
        }
        catch (Exception)
        {

            throw;
        }
    }
    [HttpPost]
    public async Task<ActionResult<DescontoMinimoDto>> Post([FromBody] DescontoMinimoDto descontoMinimo)
    {
        if (descontoMinimo is not null)
        {
            try
            {
                await _descontoMinimo.CriarDescontoMinimo(descontoMinimo);
                return new CreatedAtRouteResult("BuscarDescontoMinimo", new { id = descontoMinimo.Id }, descontoMinimo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        return BadRequest("Dados inválidos");
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<DescontoMinimoDto>> Put(int id, [FromBody] DescontoMinimoDto descontoMinimo)
    {
        if (descontoMinimo is not null)
        {
            try
            {
                if (id != descontoMinimo.Id)
                {
                    return BadRequest();
                }
                if (descontoMinimo is null)
                {
                    return BadRequest();
                }

                await _descontoMinimo.AtualizarDescontoMinimo(descontoMinimo);
                return Ok(descontoMinimo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        return BadRequest("Dados inválidos");
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DescontoMinimoDto>> Delete(int id)
    {
        try
        {
            var descontoMinimo = await _descontoMinimo.PegarPorIdDescontoMinimo(id);
            if (id != descontoMinimo.Id)
            {
                return BadRequest();
            }
            if (descontoMinimo is null)
            {
                return BadRequest();
            }
            await _descontoMinimo.DeletarDescontoMinimo(descontoMinimo.Id);
            return Ok(descontoMinimo);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
