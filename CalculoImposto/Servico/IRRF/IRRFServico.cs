using CalculoImposto.API.MapeamentoDto.IrrfDt;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF;

public class IrrfServico(IIrrfRepositorio iRRFRepositorio) : IIrrfServico
{
    public readonly IIrrfRepositorio _IRRFRepositorio = iRRFRepositorio;
    public async Task AtualizarIrrf(IrrfDto irrf)
    {
        await _IRRFRepositorio.AtualizarIrrf(irrf.ConverteDtoParaIrrf());
    }
    public async Task CriarIrrf(IrrfDto irrf)
    {
        await _IRRFRepositorio.CriarIrrf(irrf.ConverteDtoParaIrrf());
    }
    public async Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        var deducao = await _IRRFRepositorio.DeducaoFaixaCompetenciaIrrf(competencia, faixa);
        return deducao;
    }
    public async Task DeletarIrrf(int id)
    {
        var irrf = await _IRRFRepositorio.PegarPorIdIrrf(id);

        if (irrf is not null)
        {
            await _IRRFRepositorio.DeletarIrrf(irrf.Id);
        }

    }
    public async Task<int> PegarFaixaIrrf(DateTime competencia, decimal valorBrutoIrrf)
    {
        var faixa = await _IRRFRepositorio.PegarFaixaIrrf(competencia, valorBrutoIrrf);
        return faixa;
    }

    public async Task<IEnumerable<IrrfDto>> PegarPorCompetenciaIrrf(DateTime competencia)
    {
        var irrfList = await _IRRFRepositorio.PegarPorCompetenciaIrrf(competencia);
        return irrfList.ConverterIrrfParaDtos();
    }

    public async Task<IrrfDto> PegarPorIdIrrf(int id)
    {
        var irrf = await _IRRFRepositorio.PegarPorIdIrrf(id);
        return irrf.ConverteIrrfParaDto();
    }
    public async Task<IEnumerable<IrrfDto>> PegarTodosIrrf(int pagina, int tamanho, string busca)
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
