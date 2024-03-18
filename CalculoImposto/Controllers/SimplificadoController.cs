using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

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
    [HttpGet("{id:int}", Name = "BuscarSimplificado")]
    public async Task<ActionResult<SimplificadoDto>> PegarPorId(int id)
    {
        var simplificado = await _simplicadoServico.PegarPorIdSimplificado(id);

        if (simplificado is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(simplificado);
    }
    [HttpGet("Competencia/{strCompetencia}")]
    public async Task<ActionResult<IEnumerable<SimplificadoDto>>> PegarPorCompetenciaSimplificado(string strCompetencia)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        try
        {
            var simplificadoList = await _simplicadoServico.PegarPorCompetenciaSimplificado(competencia);
            if (simplificadoList is null)
            {
                return NotFound();
            }

            return Ok(simplificadoList);
        }
        catch (Exception)
        {

            throw;
        }
    }
    [HttpPost]
    public async Task<ActionResult<SimplificadoDto>> Post([FromBody] SimplificadoDto simplificado)
    {
        if (simplificado is not null)
        {
            try
            {
                await _simplicadoServico.CriarSimplificado(simplificado);
                return new CreatedAtRouteResult("BuscarSimplificado", new { id = simplificado.Id }, simplificado);
            }
            catch (Exception)
            {

                throw;
            }
        }
        return BadRequest("Dados inválidos");
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<SimplificadoDto>> Put(int id, [FromBody] SimplificadoDto simplificado)
    {
        if (simplificado is not null)
        {
            try
            {
                if (id != simplificado.Id)
                {
                    return BadRequest();
                }
                if (simplificado is null)
                {
                    return BadRequest();
                }

                await _simplicadoServico.AtualizarSimplificado(simplificado);
                return Ok(simplificado);
            }
            catch (Exception)
            {

                throw;
            }
        }
        return BadRequest("Dados inválidos");
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<SimplificadoDto>> Delete(int id)
    {
        try
        {
            var simplificado = await _simplicadoServico.PegarPorIdSimplificado(id);
            if (id != simplificado.Id)
            {
                return BadRequest();
            }
            if (simplificado is null)
            {
                return BadRequest();
            }
            await _simplicadoServico.DeletarSimplificado(simplificado.Id);
            return Ok(simplificado);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
