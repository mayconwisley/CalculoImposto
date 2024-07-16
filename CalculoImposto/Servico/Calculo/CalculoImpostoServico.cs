using CalculoImposto.API.Servico.Calculo.Interface;
using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.API.Servico.IRRF;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.INSS;
using CalculoImposto.Modelo.DTO.IRRF;
using CalculoImposto.Modelo.DTO.Pensao;

namespace CalculoImposto.API.Servico.Calculo;

public class CalculoImpostoServico(IIrrfServico iRRFServico,
        IInssServico iNSSServico,
        IDependenteServico dependente,
        ISimplificadoServico simplificado,
        IDescontoMinimoServico descontoMinimo) : ICalculoImpostoServico
{

    public readonly IIrrfServico _IRRFServico = iRRFServico;
    public readonly IInssServico _INSSServico = iNSSServico;
    public readonly IDependenteServico _dependente = dependente;
    public readonly ISimplificadoServico _simplificado = simplificado;
    public readonly IDescontoMinimoServico _descontoMinimo = descontoMinimo;

    public async Task<CalculoInssProgressivoDto> CalculoInssProgressivo(DateTime competencia, decimal baseInss)
    {
        try
        {
            CalculoInssProgressivoDto calculoInss = new()
            {
                BaseCalculo = baseInss,
                Faixas = []
            };

            decimal desconto = 0, valorInssAnterior = 0, totalDesconto = 0;

            decimal tetoInss = await _INSSServico.ValorTetoCompetenciaInss(competencia);

            if (baseInss > tetoInss)
            {
                baseInss = tetoInss;
            }

            decimal faixaInss = await _INSSServico.PegarFaixaInss(competencia, baseInss);

            for (int i = 1; i <= faixaInss; i++)
            {
                decimal porcentagemInss = await _INSSServico.PorcentagemFaixaCompetenciaInss(competencia, i);
                decimal valorInss = await _INSSServico.ValorFaixaCompetenciaInss(competencia, i);

                decimal baseInssCalculo = valorInss - valorInssAnterior;

                if (valorInss > baseInss)
                {
                    baseInssCalculo = baseInss - valorInssAnterior;
                }

                if (baseInssCalculo > baseInss)
                {
                    baseInssCalculo = baseInss - valorInssAnterior;
                }

                desconto = (baseInssCalculo * (porcentagemInss / 100));
                totalDesconto += desconto;
                valorInssAnterior = valorInss;

                calculoInss.Faixas.Add(new CalculoInssProgressivoFaixaDto()
                {
                    Faixa = $"{i}ª Faixa",
                    Base = Math.Round(baseInssCalculo, 2),
                    Porcentagem = Math.Round(porcentagemInss, 2),
                    Imposto = Math.Round(desconto, 2)
                });
            }
            calculoInss.TotalDesconto = Math.Round(totalDesconto, 2);

            return calculoInss;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<CalculoNormalDto> CalculoIrrfNormal(DateTime competencia, decimal valorBruto, decimal baseInss, int qtdDependete)
    {
        decimal valorDependente = await _dependente.ValorDependenteCompetencia(competencia);
        decimal valorInss = await _INSSServico.DescontoInssProgressivo(competencia, baseInss);

        decimal baseIrrf = valorBruto - valorInss - (valorDependente * qtdDependete);

        int faixaIrrf = await _IRRFServico.PegarFaixaIrrf(competencia, baseIrrf);
        decimal porcentagemIrrf = await _IRRFServico.PorcentagemFaixaCompetenciaIrrf(competencia, faixaIrrf);
        decimal deducaoIrrf = await _IRRFServico.DeducaoFaixaCompetenciaIrrf(competencia, faixaIrrf);

        decimal desconto = (baseIrrf * (porcentagemIrrf / 100)) - deducaoIrrf;
        desconto = Math.Round(desconto, 2);

        decimal aliquitaEfetiva = CalculoAliquotaEfetiva.Calculo(desconto, valorBruto);

        CalculoNormalDto calculoNormal = new()
        {
            ValorBruto = valorBruto,
            ValorInss = valorInss,
            QtdDependente = qtdDependete,
            ValorDependente = valorDependente,
            ValorTotalDependente = (qtdDependete * valorDependente),
            ValorBaseIr = baseIrrf,
            Porcentagem = porcentagemIrrf,
            Deducao = deducaoIrrf,
            Desconto = desconto,
            AliquotaEfetiva = aliquitaEfetiva
        };
        return calculoNormal;
    }
    public async Task<CalculoProgressivoDto> CalculoIrrfProgressivo(DateTime competencia, decimal valorBruto, decimal baseInss, int qtdDependente)
    {
        decimal valorDependente = await _dependente.ValorDependenteCompetencia(competencia);
        decimal valorInss = await _INSSServico.DescontoInssProgressivo(competencia, baseInss);

        decimal baseIrrf = valorBruto - valorInss - (valorDependente * qtdDependente);

        int faixaIrrf = await _IRRFServico.PegarFaixaIrrf(competencia, baseIrrf);
        decimal valorIrrfAnterior = 0, totalDesconto = 0;

        CalculoProgressivoDto calculoProgressivo = new()
        {
            ValorBruto = valorBruto,
            ValorInss = Math.Round(valorInss, 2),
            QtdDependente = qtdDependente,
            ValorDependente = valorDependente,
            ValorTotalDependente = Math.Round((qtdDependente * valorDependente), 2),
            ValorBaseIr = Math.Round(baseIrrf, 2),
            Faixas = []
        };

        for (int i = 1; i <= faixaIrrf; i++)
        {
            decimal porcentagemIrrf = await _IRRFServico.PorcentagemFaixaCompetenciaIrrf(competencia, i);
            decimal valorIrrf = await _IRRFServico.ValorFaixaCompetenciaIrrf(competencia, i);

            decimal baseIrrfCalculo = valorIrrf - valorIrrfAnterior;

            if (valorIrrf > baseIrrf)
            {
                baseIrrfCalculo = baseIrrf - valorIrrfAnterior;
            }

            if (baseIrrfCalculo > valorBruto)
            {
                baseIrrfCalculo = baseIrrf - valorIrrfAnterior;
            }

            decimal desconto = (baseIrrfCalculo * (porcentagemIrrf / 100));
            totalDesconto += desconto;
            valorIrrfAnterior = valorIrrf;

            decimal aliquitaEfetiva = CalculoAliquotaEfetiva.Calculo(desconto, valorBruto);

            calculoProgressivo.Faixas.Add(new CalculoProgressivoFaixaDto
            {
                Faixa = $"{i}ª Faixa",
                ValorBaseIr = Math.Round(baseIrrfCalculo, 2),
                Porcentagem = Math.Round(porcentagemIrrf, 2),
                ValorDesconto = Math.Round(desconto, 2),
                AliquotaEfetiva = Math.Round(aliquitaEfetiva, 2)
            });
        }
        calculoProgressivo.TotalDesconto = Math.Round(totalDesconto, 2);
        return await Task.FromResult(calculoProgressivo);
    }
    public async Task<CalculoSimplificadoDto> CalculoIrrfSimplificado(DateTime competencia, decimal valorBruto)
    {
        if (competencia < DateTime.Parse("01/05/2023"))
        {
            return new();
        }

        decimal valorSimplificado = await _simplificado.ValorSimplificadoCompetencia(competencia);
        decimal baseIrrf = valorBruto - valorSimplificado;

        int faixaIrrf = await _IRRFServico.PegarFaixaIrrf(competencia, baseIrrf);
        decimal porcentagemIrrf = await _IRRFServico.PorcentagemFaixaCompetenciaIrrf(competencia, faixaIrrf);
        decimal deducaoIrrf = await _IRRFServico.DeducaoFaixaCompetenciaIrrf(competencia, faixaIrrf);

        decimal desconto = (baseIrrf * (porcentagemIrrf / 100)) - deducaoIrrf;
        desconto = Math.Round(desconto, 2);

        decimal aliquitaEfetiva = CalculoAliquotaEfetiva.Calculo(desconto, valorBruto);

        CalculoSimplificadoDto calculoSimplificado = new()
        {
            ValorBruto = valorBruto,
            ValorSimplificado = valorSimplificado,
            ValorBaseIr = baseIrrf,
            PorcentagemIrrf = porcentagemIrrf,
            DeduçãoIrrf = deducaoIrrf,
            Desconto = desconto,
            Aliquota = aliquitaEfetiva
        };
        return calculoSimplificado;
    }
    public async Task<CalculoPensaoDto> CalculoPensao(DateTime competencia, decimal porcentagemPensao, decimal valorBruto, decimal baseInss, decimal outrosDescontos, int qtdDependente, bool simplificado)
    {
        CalculoPensaoDto calculoPensao = new();
        calculoPensao.Faixas = [];


        decimal valorDependente = await _dependente.ValorDependenteCompetencia(competencia);
        decimal valorInss = await _INSSServico.DescontoInssProgressivo(competencia, baseInss);

        decimal baseIrrf = 0m;
        decimal valorPensao = 0m;
        decimal valorPensaoAnterior = 0m;
        decimal descontoIrrf = 0m;
        decimal baseCalculoSimplificado = 0m;
        int seqCalculo = 0;

        if (simplificado)
        {
            decimal valorSimplificado = await _simplificado.ValorSimplificadoCompetencia(competencia);
            baseIrrf = valorBruto - outrosDescontos - valorSimplificado;
            baseCalculoSimplificado = valorBruto - outrosDescontos - valorInss;
        }
        else
        {
            baseIrrf = valorBruto - outrosDescontos - valorInss - (valorDependente * qtdDependente);
        }

        calculoPensao.PorcentagemPensao = Math.Round(porcentagemPensao, 2);

        do
        {
            CalculoPensaoFaixaDto calculoPensaoFaixa = new();
            seqCalculo++;
            int faixaIrrf = await _IRRFServico.PegarFaixaIrrf(competencia, (baseIrrf - valorPensao));
            decimal porcentagemIrrf = await _IRRFServico.PorcentagemFaixaCompetenciaIrrf(competencia, faixaIrrf) / 100m;
            decimal parcelaDeduzirIrrf = await _IRRFServico.DeducaoFaixaCompetenciaIrrf(competencia, faixaIrrf);

            descontoIrrf = ((baseIrrf - valorPensao) * (porcentagemIrrf)) - parcelaDeduzirIrrf;

            valorPensaoAnterior = valorPensao;

            calculoPensaoFaixa.Faixa = $"{seqCalculo}ª Faixa";
            calculoPensaoFaixa.Porcentagem = Math.Round(porcentagemIrrf * 100, 2);
            calculoPensaoFaixa.BaseIr = Math.Round(baseIrrf - valorPensaoAnterior, 2);
            calculoPensaoFaixa.ValorIr = Math.Round(descontoIrrf, 2);


            if (simplificado)
            {
                valorPensao = (baseCalculoSimplificado - descontoIrrf) * (porcentagemPensao / 100);

                calculoPensaoFaixa.BasePensao = Math.Round(baseCalculoSimplificado - descontoIrrf, 2);
                calculoPensaoFaixa.ValorPensao = Math.Round(valorPensao, 2);

            }
            else
            {
                decimal baseIrrfNova = baseIrrf - (valorDependente * qtdDependente) - valorPensaoAnterior;

                valorPensao = (baseIrrf - (porcentagemIrrf * baseIrrfNova) + parcelaDeduzirIrrf) * (porcentagemPensao / 100);


                calculoPensaoFaixa.BasePensao = Math.Round(baseIrrf - descontoIrrf, 2);
                calculoPensaoFaixa.ValorPensao = Math.Round(valorPensao, 2);
            }
            calculoPensao.Faixas.Add(calculoPensaoFaixa);

        } while (Math.Abs(valorPensao - valorPensaoAnterior) > 0.01m);
        calculoPensao.TotalDesconto = Math.Round(valorPensao + descontoIrrf, 2);

        return calculoPensao;
    }
}
