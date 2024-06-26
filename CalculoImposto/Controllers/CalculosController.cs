﻿using CalculoImposto.API.Servico.Calculo.Interface;
using CalculoImposto.Modelo.DTO.INSS;
using CalculoImposto.Modelo.DTO.IRRF;
using CalculoImposto.Modelo.DTO.Pensao;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculosController(ICalculoImpostoServico calculoImposto) : ControllerBase
{
    private readonly ICalculoImpostoServico _calculoImposto = calculoImposto;

    [HttpGet("Inss/Progressivo/{strCompetencia}/{baseInss:decimal}")]
    public async Task<ActionResult<CalculoInssProgressivoDto>> CalculoInssProgressivo(string strCompetencia, decimal baseInss)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        var calculoInss = await _calculoImposto.CalculoInssProgressivo(competencia, baseInss);

        if (calculoInss is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(calculoInss);
    }
    [HttpGet("Irrf/Normal/{strCompetencia}/{valorBrutoIrrf:decimal}/{baseInss:decimal}/{qtDependente:int}")]
    public async Task<ActionResult<CalculoNormalDto>> CalculoIrrfNormal(string strCompetencia, decimal valorBrutoIrrf, decimal baseInss, int qtDependente)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        var calculoIrrf = await _calculoImposto.CalculoIrrfNormal(competencia, valorBrutoIrrf, baseInss, qtDependente);

        if (calculoIrrf is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(calculoIrrf);
    }
    [HttpGet("Irrf/Progressivo/{strCompetencia}/{valorBrutoIrrf:decimal}/{baseInss:decimal}/{qtDependente:int}")]
    public async Task<ActionResult<CalculoProgressivoDto>> CalculoIrrfProgressivo(string strCompetencia, decimal valorBrutoIrrf, decimal baseInss, int qtDependente)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        var calculoIrrf = await _calculoImposto.CalculoIrrfProgressivo(competencia, valorBrutoIrrf, baseInss, qtDependente);

        if (calculoIrrf is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(calculoIrrf);
    }
    [HttpGet("Irrf/Simplificado/{strCompetencia}/{valorBrutoIrrf:decimal}")]
    public async Task<ActionResult<CalculoSimplificadoDto>> CalculoIrrfSimplificado(string strCompetencia, decimal valorBrutoIrrf)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        var calculoIrrf = await _calculoImposto.CalculoIrrfSimplificado(competencia, valorBrutoIrrf);

        if (calculoIrrf is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(calculoIrrf);
    }
    [HttpGet("Pensao/{strCompetencia}/{porcentagemPensao:decimal}/{valorBruto:decimal}/{baseInss:decimal}/{outrosDescontos:decimal}/{qtdDependente:int}/{simplificado:bool}")]
    public async Task<ActionResult<CalculoPensaoDto>> CalculoPensao(string strCompetencia, decimal porcentagemPensao, decimal valorBruto, decimal baseInss, decimal outrosDescontos, int qtdDependente, bool simplificado)
    {
        DateTime competencia = DateTime.Parse(strCompetencia.Replace("%2F", "/"));
        var calculoPensao = await _calculoImposto.CalculoPensao(competencia, porcentagemPensao, valorBruto, baseInss, outrosDescontos, qtdDependente, simplificado);

        if (calculoPensao is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(calculoPensao);
    }
}
