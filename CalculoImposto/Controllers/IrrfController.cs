﻿using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IrrfController(IIRRFServico irrfServico) : ControllerBase
{
    private readonly IIRRFServico _irrfServico = irrfServico;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IRRFDto>>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10, [FromQuery] string busca = "")
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
    public async Task<ActionResult<IRRFDto>> PegarPorId(int id)
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
    [HttpPost]
    public async Task<ActionResult<IRRFDto>> Post([FromBody] IRRFDto irrf)
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
    public async Task<ActionResult<IRRFDto>> Put(int id, [FromBody] IRRFDto irrf)
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
    public async Task<ActionResult<IRRFDto>> Delete(int id)
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
