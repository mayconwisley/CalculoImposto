using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DependenteController(IDependenteServico dependente) : ControllerBase
{
    private readonly IDependenteServico _dependente = dependente;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DependenteDto>>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
    {
        var dependenteList = await _dependente.PegarTodos(pagina, tamanho);
        decimal totalDependente = await _dependente.TotalDependente();
        decimal totalPagina = (totalDependente / tamanho) <= 0 ? 1 : Math.Ceiling(totalDependente / tamanho);

        if (tamanho == 1)
        {
            totalPagina = totalDependente;
        }

        if (!dependenteList.Any())
        {
            return NotFound("Sem dados");
        }

        return Ok(new
        {
            totalDependente,
            pagina,
            totalPagina,
            tamanho,
            dependenteList
        });
    }
    [HttpGet("{id:int}", Name = "BuscarDependente")]
    public async Task<ActionResult<DependenteDto>> PegarPorId(int id)
    {
        var dependente = await _dependente.PegarPorId(id);
        if (dependente is not null)
        {
            return Ok(dependente);
        }
        return NotFound();
    }
    [HttpGet("Competencia/{strComeptencia}")]
    public async Task<ActionResult<DependenteDto>> PegarPorCompetencia(string strComeptencia)
    {
        DateTime competencia = DateTime.Parse(strComeptencia.Replace("%2F", "/"));
        try
        {
            var dependente = await _dependente.PegarPorCompetenciaDependente(competencia);
            if (dependente is not null)
            {
                return Ok(dependente);
            }
            return NotFound();
        }
        catch (Exception)
        {

            throw;
        }
    }
    [HttpPost]
    public async Task<ActionResult<DependenteDto>> Post([FromBody] DependenteDto dependente)
    {
        if (dependente is not null)
        {
            try
            {
                await _dependente.Criar(dependente);
                return new CreatedAtRouteResult("BuscarDependente", new { id = dependente.Id }, dependente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        return BadRequest();
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<DependenteDto>> Put(int id, [FromBody] DependenteDto dependente)
    {
        if (dependente is not null)
        {
            try
            {
                if (id != dependente.Id)
                {
                    return BadRequest();
                }

                if (dependente is null)
                {
                    return BadRequest();
                }

                await _dependente.Atualizar(dependente);
                return Ok(dependente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        return BadRequest();
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DependenteDto>> Delete(int id)
    {
        try
        {
            var dependente = await _dependente.PegarPorId(id);
            if (id != dependente.Id)
            {
                return BadRequest();
            }
            if (dependente is null)
            {
                return BadRequest();
            }

            await _dependente.Deletar(dependente.Id);
            return Ok(dependente);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
