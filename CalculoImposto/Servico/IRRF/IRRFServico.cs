using CalculoImposto.API.MapeamentoDto.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF;

public class IrrfServico(IIrrfRepositorio iRRFRepositorio) : IIrrfServico
{
    public readonly IIrrfRepositorio _IRRFRepositorio = iRRFRepositorio;

    public async Task<IrrfDto> Atualizar(IrrfDto entity)
    {
        var irrfDto = await _IRRFRepositorio.Atualizar(entity.ConverteDtoParaIrrf());
        return irrfDto.ConverteIrrfParaDto();
    }
    public async Task<IrrfDto> Criar(IrrfDto entity)
    {
        var irrfDto = await _IRRFRepositorio.Criar(entity.ConverteDtoParaIrrf());
        return irrfDto.ConverteIrrfParaDto();
    }
    public async Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        var deducao = await _IRRFRepositorio.DeducaoFaixaCompetenciaIrrf(competencia, faixa);
        return deducao;
    }
    public async Task<IrrfDto> Deletar(int id)
    {
        var irrfDto = await _IRRFRepositorio.PegarPorId(id);

        if (irrfDto is not null)
        {
            await _IRRFRepositorio.Deletar(irrfDto.Id);
            return irrfDto.ConverteIrrfParaDto();
        }
        return new();
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
    public async Task<IrrfDto> PegarPorId(int id)
    {
        var irrfDto = await _IRRFRepositorio.PegarPorId(id);
        return irrfDto.ConverteIrrfParaDto();
    }
    public async Task<IEnumerable<IrrfDto>> PegarTodos(int pagina, int tamanho)
    {
        var irrfList = await _IRRFRepositorio.PegarTodos(pagina, tamanho);
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
