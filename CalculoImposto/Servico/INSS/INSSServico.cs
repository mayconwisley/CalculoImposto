using CalculoImposto.API.MapeamentoDto.InssDto;
using CalculoImposto.API.Repositorio.INSS;
using CalculoImposto.API.Repositorio.INSS.Interface;
using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.Modelo.DTO.INSS;

namespace CalculoImposto.API.Servico.INSS;

public class INSSServico(IINSSRepositorio iNSSRepositorio) : IINSSServico
{
    private readonly IINSSRepositorio _INSSRepositorio = iNSSRepositorio;

    public async Task AtualizarInss(INSSDto inss)
    {
        await _INSSRepositorio.AtualizarInss(inss.ConverteDtoInss());
    }

    public async Task CriarInss(INSSDto inss)
    {
        await _INSSRepositorio.CriarInss(inss.ConverteDtoInss());
    }

    public async Task DeletarInss(int id)
    {
        var inss = await PegarPorIdInss(id);
        if (inss is not null)
        {
            await _INSSRepositorio.DeletarInss(inss.Id);
        }
    }

    public async Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss)
    {
        var faixaInss = await _INSSRepositorio.PegarFaixaInss(competencia, baseInss);
        return faixaInss;
    }

    public async Task<INSSDto> PegarPorIdInss(int id)
    {
        var inss = await _INSSRepositorio.PegarPorIdInss(id);
        return inss.ConverteInssDto();
    }

    public async Task<IEnumerable<INSSDto>> PegarTodosInss(int pagina, int tamanho, string busca)
    {
        var inssList = await _INSSRepositorio.PegarTodosInss(pagina, tamanho, busca);
        return inssList.ConverterInssParaDtos();
    }

    public async Task<IEnumerable<INSSDto>> PegarTodosPorCompetenciaInss(DateTime competencia)
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
