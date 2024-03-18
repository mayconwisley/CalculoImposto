using CalculoImposto.API.MapeamentoDto.IrrfDto;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF;

public class IRRFServico(IIRRFRepositorio iRRFRepositorio) : IIRRFServico
{
    public readonly IIRRFRepositorio _IRRFRepositorio = iRRFRepositorio;

    public async Task AtualizarIrrf(IRRFDto irrf)
    {
        await _IRRFRepositorio.AtualizarIrrf(irrf.ConverteDtoParaIrrf());
    }

    public Task<string> CalculoIrrfNormal(DateTime competencia, decimal valorBruto, decimal valorInss, int qtdDependete)
    {
        throw new NotImplementedException();
    }

    public Task<string> CalculoIrrfProgressivo(DateTime competencia, decimal valorBruto, decimal valorInss, int qtdDependete)
    {
        throw new NotImplementedException();
    }

    public Task<string> CalculoIrrfSimplificado(DateTime competencia, decimal valorBruto, decimal valorInss)
    {
        throw new NotImplementedException();
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
