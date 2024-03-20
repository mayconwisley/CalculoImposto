using CalculoImposto.API.MapeamentoDto.INSS;
using CalculoImposto.API.Repositorio.INSS.Interface;
using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.Modelo.DTO.INSS;

namespace CalculoImposto.API.Servico.INSS;

public class InssServico(IInssRepositorio iNSSRepositorio) : IInssServico
{
    private readonly IInssRepositorio _INSSRepositorio = iNSSRepositorio;

    public async Task AtualizarInss(InssDto inss)
    {
        await _INSSRepositorio.AtualizarInss(inss.ConverteDtoParaInss());
    }

    public async Task CriarInss(InssDto inss)
    {
        await _INSSRepositorio.CriarInss(inss.ConverteDtoParaInss());
    }

    public async Task DeletarInss(int id)
    {
        var inss = await PegarPorIdInss(id);
        if (inss is not null)
        {
            await _INSSRepositorio.DeletarInss(inss.Id);
        }
    }

    public async Task<decimal> DescontoInssProgressivo(DateTime competencia, decimal baseInss)
    {
        try
        {
            decimal desconto = 0, valorInssAnterior = 0;

            decimal tetoInss = await ValorTetoCompetenciaInss(competencia);
            decimal faixaInss = await PegarFaixaInss(competencia, baseInss);

            if (baseInss > tetoInss)
            {
                baseInss = tetoInss;
            }

            for (int i = 1; i <= faixaInss; i++)
            {
                decimal porcentagemInss = await PorcentagemFaixaCompetenciaInss(competencia, i);
                decimal valorInss = await ValorFaixaCompetenciaInss(competencia, i);

                decimal baseInssCalculo = valorInss - valorInssAnterior;

                if (valorInss > baseInss)
                {
                    baseInssCalculo = baseInss - valorInssAnterior;
                }

                if (baseInssCalculo > baseInss)
                {
                    baseInssCalculo = baseInss - valorInssAnterior;
                }

                desconto += (baseInssCalculo * (porcentagemInss / 100));
                valorInssAnterior = valorInss;
            }

            return desconto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss)
    {
        var faixaInss = await _INSSRepositorio.PegarFaixaInss(competencia, baseInss);
        return faixaInss;
    }

    public async Task<InssDto> PegarPorIdInss(int id)
    {
        var inss = await _INSSRepositorio.PegarPorIdInss(id);
        return inss.ConverteInssParaDto();
    }

    public async Task<IEnumerable<InssDto>> PegarTodosInss(int pagina, int tamanho, string busca)
    {
        var inssList = await _INSSRepositorio.PegarTodosInss(pagina, tamanho, busca);
        return inssList.ConverterInssParaDtos();
    }

    public async Task<IEnumerable<InssDto>> PegarTodosPorCompetenciaInss(DateTime competencia)
    {
        var inssList = await _INSSRepositorio.PegarTodosPorCompetenciaInss(competencia);
        return inssList.ConverterInssParaDtos();
    }

    public async Task<decimal> PorcentagemFaixaCompetenciaInss(DateTime competencia, int faixa)
    {
        var porcentagemInss = await _INSSRepositorio.PorcentagemFaixaCompetenciaInss(competencia, faixa);
        return porcentagemInss;
    }

    public async Task<int> TotalInss(string busca)
    {
        var totalInss = await _INSSRepositorio.TotalInss(busca);
        return totalInss;
    }

    public async Task<int> UltimaFaixaCompetenciaInss(DateTime competencia)
    {
        var ultimaCompetencia = await _INSSRepositorio.UltimaFaixaCompetenciaInss(competencia);
        return ultimaCompetencia;
    }

    public async Task<decimal> ValorFaixaCompetenciaInss(DateTime competencia, int faixa)
    {
        var valorFaixa = await _INSSRepositorio.ValorFaixaCompetenciaInss(competencia, faixa);
        return valorFaixa;
    }

    public async Task<decimal> ValorTetoCompetenciaInss(DateTime competencia)
    {
        var valorTeto = await _INSSRepositorio.ValorTetoCompetenciaInss(competencia);
        return valorTeto;
    }
}
