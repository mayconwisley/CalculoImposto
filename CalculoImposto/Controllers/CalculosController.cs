using CalculoImposto.API.Servico.Calculo.Interface;
using CalculoImposto.Modelo.DTO.Estabilidade;
using CalculoImposto.Modelo.DTO.INSS;
using CalculoImposto.Modelo.DTO.IRRF;
using CalculoImposto.Modelo.DTO.Pensao;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculosController(ICalculoImpostoServico calculoImposto, ICalculoBaseEstabilidadeServico calculoBaseEstabilidade) : ControllerBase
{
    private readonly ICalculoImpostoServico _calculoImposto = calculoImposto;
    private readonly ICalculoBaseEstabilidadeServico _calculoBaseEstabilidade = calculoBaseEstabilidade;

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

    [HttpGet("Estabilidade/{valorMedia:decimal}/{diasBase:int}/{diasEstabilidade:int}/{fgts8:bool}/{fgts40:bool}")]
    public async Task<ActionResult<CalculoEstabilidadeDto>> CalculoEstabilidade(decimal valorMedia = 0, int diasBase = 30, int diasEstabilidade = 0, bool fgts8 = true, bool fgts40 = true)
    {

        var indenizacao = await _calculoBaseEstabilidade.Indenizacao(valorMedia, diasBase, diasEstabilidade);
        var decimoTerceiro = await _calculoBaseEstabilidade.DecimoTerceiro(valorMedia, diasEstabilidade);
        var ferias = await _calculoBaseEstabilidade.Ferias(valorMedia, diasEstabilidade);
        var tercoFerias = await _calculoBaseEstabilidade.TercoFerias(ferias);
        decimal fgts08 = 0, fgts040 = 0;

        if (fgts8)
        {
            fgts08 = await _calculoBaseEstabilidade.FGTS8(indenizacao, decimoTerceiro);
        }
        else
        {
            fgts40 = false;
        }

        if (fgts40)
        {
            fgts040 = await _calculoBaseEstabilidade.FGTS40(fgts08);
        }

        CalculoEstabilidadeDto calculoEstabilidadeDto = new()
        {
            Indenizacao = indenizacao,
            DecimoTerceiro = decimoTerceiro,
            Ferias = ferias,
            TercoFerias = tercoFerias,
            FGTS8 = fgts08,
            FGTS40 = fgts040

        };


        if (calculoEstabilidadeDto is null)
        {
            return NotFound("Sem dados");
        }

        return Ok(calculoEstabilidadeDto);
    }
}
