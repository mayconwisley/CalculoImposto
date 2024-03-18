using CalculoImposto.API.MapeamentoDto.IrrfDto;
using CalculoImposto.API.Repositorio.INSS.Interface;
using CalculoImposto.API.Repositorio.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text;

namespace CalculoImposto.API.Servico.IRRF;

public class IRRFServico(IIRRFRepositorio iRRFRepositorio,
        IINSSServico iNSSServico,
        IDependenteRepositorio dependente,
        ISimplificadoRepositorio simplificado,
        IDescontoMinimoRespositorio descontoMinimo) : IIRRFServico
{
    public readonly IIRRFRepositorio _IRRFRepositorio = iRRFRepositorio;
    public readonly IINSSServico _INSSServico = iNSSServico;
    public readonly IDependenteRepositorio _dependente = dependente;
    public readonly ISimplificadoRepositorio _simplificado = simplificado;
    public readonly IDescontoMinimoRespositorio _descontoMinimo = descontoMinimo;

    public async Task AtualizarIrrf(IRRFDto irrf)
    {
        await _IRRFRepositorio.AtualizarIrrf(irrf.ConverteDtoParaIrrf());
    }

    public async Task<string> CalculoIrrfNormal(DateTime competencia, decimal valorBruto, decimal baseInss, int qtdDependete)
    {
        decimal valorDependente = await _dependente.ValorDependenteCompetencia(competencia);
        decimal valorInss = await _INSSServico.DescontoInssProgressivo(competencia, baseInss);

        decimal baseIrrf = valorBruto - valorInss - (valorDependente * qtdDependete);

        int faixaIrrf = await _IRRFRepositorio.PegarFaixaIrrf(competencia, baseIrrf);
        decimal porcentagemIrrf = await _IRRFRepositorio.PorcentagemFaixaCompetenciaIrrf(competencia, faixaIrrf);
        decimal deducaoIrrf = await _IRRFRepositorio.DeducaoFaixaCompetenciaIrrf(competencia, faixaIrrf);

        decimal desconto = (baseIrrf * (porcentagemIrrf / 100)) - deducaoIrrf;
        desconto = Math.Round(desconto, 2);

        decimal aliquitaEfetiva = 0;

        try
        {
            aliquitaEfetiva = (desconto / valorBruto) * 100;
            aliquitaEfetiva = Math.Truncate(aliquitaEfetiva * 100) / 100;
        }
        catch (Exception)
        {
            aliquitaEfetiva = 0m;
        }

        StringBuilder strMensagem = new StringBuilder();

        strMensagem.Append('{');
        strMensagem.Append($""" "ValorBruto": "{valorBruto:#,##0.00}", """);
        strMensagem.Append($""" "ValorInss" : "{valorInss:#,##.00}", """);
        strMensagem.Append($""" "QtdDepndente": "{qtdDependete}", """);
        strMensagem.Append($""" "ValorDependente" : "{valorDependente:#,##0.00}", """);
        strMensagem.Append($""" "ValorTotalDependente" : "{(qtdDependete * valorDependente):#,##0.00}", """);
        strMensagem.Append($""" "ValorBaseIr" : "{baseIrrf:#,##0.00}", """);
        strMensagem.Append($""" "Porcentagem" : "{porcentagemIrrf:#,##0.00}", """);
        strMensagem.Append($""" "DeducaoFaixa" : "{deducaoIrrf:#,##0.00}", """);
        strMensagem.Append($""" "ValorDesconto" : "{desconto:#,##0.00}", """);
        strMensagem.Append($""" "AliquotaEfetiva" : "{aliquitaEfetiva:#,##0.00}" """);
        strMensagem.Append('}');

        return await Task.FromResult(strMensagem.ToString());
    }

    public async Task<string> CalculoIrrfProgressivo(DateTime competencia, decimal valorBruto, decimal baseInss, int qtdDependete)
    {
        decimal valorDependente = await _dependente.ValorDependenteCompetencia(competencia);
        decimal valorInss = await _INSSServico.DescontoInssProgressivo(competencia, baseInss);

        decimal baseIrrf = valorBruto - valorInss - (valorDependente * qtdDependete);

        int faixaIrrf = await _IRRFRepositorio.PegarFaixaIrrf(competencia, baseIrrf);

        decimal desconto = 0;
        decimal valorIrrfAnterior = 0;

        StringBuilder strMensagem = new();

        strMensagem.Append('{');
        strMensagem.Append($""" "ValorBruto": "{valorBruto:#,##0.00}", """);
        strMensagem.Append($""" "ValorInss" : "{valorInss:#,##.00}", """);
        strMensagem.Append($""" "QtdDepndente": "{qtdDependete}", """);
        strMensagem.Append($""" "ValorDependente" : "{valorDependente:#,##0.00}", """);
        strMensagem.Append($""" "ValorTotalDependente" : "{(qtdDependete * valorDependente):#,##0.00}", """);
        strMensagem.Append($""" "ValorBaseIr" : "{baseIrrf:#,##0.00}", """);

        for (int i = 1; i <= faixaIrrf; i++)
        {
            decimal porcentagemIrrf = await _IRRFRepositorio.PorcentagemFaixaCompetenciaIrrf(competencia, i);
            decimal valorIrrf = await _IRRFRepositorio.ValorFaixaCompetenciaIrrf(competencia, i);

            decimal baseIrrfCalculo = valorIrrf - valorIrrfAnterior;

            if (valorIrrf > baseIrrf)
            {
                baseIrrfCalculo = baseIrrf - valorIrrfAnterior;
            }

            if (baseIrrfCalculo > valorBruto)
            {
                baseIrrfCalculo = baseIrrf - valorIrrfAnterior;
            }

            desconto = (baseIrrfCalculo * (porcentagemIrrf / 100));
            valorIrrfAnterior = valorIrrf;

            decimal aliquitaEfetiva = CalculoAliquotaEfetiva.Calculo(desconto, valorBruto);

            strMensagem.Append($""" "Faixa" : "{i}ª Faixa", """);
            strMensagem.Append($""" "ValorBaseIr" : "{baseIrrfCalculo:#,##0.00}", """);
            strMensagem.Append($""" "Porcentagem" : "{porcentagemIrrf:#,##0.00}", """);
            strMensagem.Append($""" "ValorDesconto" : "{desconto:#,##0.00}", """);
            strMensagem.Append($""" "AliquotaEfetiva" : "{aliquitaEfetiva:#,##0.00}", """);
        }
        strMensagem.Append('}');
        return await Task.FromResult(strMensagem.ToString());
    }

    public async Task<string> CalculoIrrfSimplificado(DateTime competencia, decimal valorBruto)
    {
        if (competencia < DateTime.Parse("01/05/2023"))
        {
            return await Task.FromResult("Calculo simplificado é a parti de 05/2023");
        }

        decimal valorSimplificado = await _simplificado.ValorSimplificadoCompetencia(competencia);
        decimal baseIrrf = valorBruto - valorSimplificado;

        int faixaIrrf = await _IRRFRepositorio.PegarFaixaIrrf(competencia, baseIrrf);
        decimal porcentagemIrrf = await _IRRFRepositorio.PorcentagemFaixaCompetenciaIrrf(competencia, faixaIrrf);
        decimal deducaoIrrf = await _IRRFRepositorio.DeducaoFaixaCompetenciaIrrf(competencia, faixaIrrf);

        decimal desconto = (baseIrrf * (porcentagemIrrf / 100)) - deducaoIrrf;
        desconto = Math.Round(desconto, 2);

        decimal aliquitaEfetiva = 0;

        try
        {
            aliquitaEfetiva = (desconto / valorBruto) * 100;
            aliquitaEfetiva = Math.Truncate(aliquitaEfetiva * 100) / 100;
        }
        catch (Exception)
        {
            aliquitaEfetiva = 0m;
        }

        StringBuilder strMensagem = new StringBuilder();

        strMensagem.Append('{');
        strMensagem.Append($""" "ValorBruto": "{valorBruto:#,##0.00}", """);

        strMensagem.Append($""" "ValorDeducaoSimplifcada" : "{valorSimplificado:#,##0.00}", """);
        strMensagem.Append($""" "ValorBaseIr" : "{baseIrrf:#,##0.00}", """);
        strMensagem.Append($""" "Porcentagem" : "{porcentagemIrrf:#,##0.00}", """);
        strMensagem.Append($""" "DeducaoFaixa" : "{deducaoIrrf:#,##0.00}", """);
        strMensagem.Append($""" "ValorDesconto" : "{desconto:#,##0.00}", """);
        strMensagem.Append($""" "AliquotaEfetiva" : "{aliquitaEfetiva:#,##0.00}" """);
        strMensagem.Append('}');

        return await Task.FromResult(strMensagem.ToString());
    }

    public async Task CriarIrrf(IRRFDto irrf)
    {
        await _IRRFRepositorio.CriarIrrf(irrf.ConverteDtoParaIrrf());
    }

    public Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        throw new NotImplementedException();
    }

    public async Task DeletarIrrf(int id)
    {
        var irrf = await _IRRFRepositorio.PegarPorIdIrrf(id);

        if (irrf is not null)
        {
            await _IRRFRepositorio.DeletarIrrf(irrf.Id);
        }

    }

    public async Task<int> PegarFaixaIrrf(DateTime competencia, decimal baseIrrf)
    {
        var faixa = await _IRRFRepositorio.PegarFaixaIrrf(competencia, baseIrrf);
        return faixa;
    }

    public async Task<IRRFDto> PegarPorIdIrrf(int id)
    {
        var irrf = await _IRRFRepositorio.PegarPorIdIrrf(id);
        return irrf.ConverteIrrfParaDto();
    }

    public async Task<IEnumerable<IRRFDto>> PegarTodosIrrf(int pagina, int tamanho, string busca)
    {
        var irrfList = await _IRRFRepositorio.PegarTodosIrrf(pagina, tamanho, busca);
        return irrfList.ConverterIrrfParaDtos();
    }

    public async Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        var porcentagem = await _IRRFRepositorio.PorcentagemFaixaCompetenciaIrrf(competencia, faixa);
        return porcentagem;
    }

    public async Task<int> TotalIrrf()
    {
        var totalIrrf = await _IRRFRepositorio.TotalIrrf();
        return totalIrrf;
    }

    public async Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        var valor = await _IRRFRepositorio.ValorFaixaCompetenciaIrrf(competencia, faixa);
        return valor;
    }
}
