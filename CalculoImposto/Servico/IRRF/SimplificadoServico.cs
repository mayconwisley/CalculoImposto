using CalculoImposto.API.MapeamentoDto.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF;

public class SimplificadoServico(ISimplificadoRepositorio simplificado) : ISimplificadoServico
{
    private readonly ISimplificadoRepositorio _simplificado = simplificado;

    public async Task AtualizarSimplificado(SimplificadoDto simplificado)
    {
        await _simplificado.AtualizarSimplificado(simplificado.ConverterDtoParaSimplificado());
    }

    public async Task CriarSimplificado(SimplificadoDto simplificado)
    {
        await _simplificado.CriarSimplificado(simplificado.ConverterDtoParaSimplificado());
    }

    public async Task DeletarSimplificado(int id)
    {
        var simplificado = await _simplificado.PegarPorIdSimplificado(id);
        if (simplificado is not null)
        {
            await _simplificado.DeletarSimplificado(simplificado.Id);
        }
    }

    public async Task<SimplificadoDto> PegarPorCompetenciaSimplificado(DateTime competencia)
    {
        var simplificadoList = await _simplificado.PegarPorCompetenciaSimplificado(competencia);
        return simplificadoList.ConverterSimplificadoParaDto();
    }

    public async Task<SimplificadoDto> PegarPorIdSimplificado(int id)
    {
        var simplificado = await _simplificado.PegarPorIdSimplificado(id);
        return simplificado.ConverterSimplificadoParaDto();
    }

    public async Task<IEnumerable<SimplificadoDto>> PegarTodosSimplificado(int pagina, int tamanho, string busca)
    {
        var simplificadoList = await _simplificado.PegarTodosSimplificado(pagina, tamanho, busca);
        return simplificadoList.ConverterSimplificadosParaDtos();
    }

    public async Task<int> TotalSimplificado()
    {
        var totalSimplificado = await _simplificado.TotalSimplificado();
        return totalSimplificado;
    }

    public async Task<decimal> ValorSimplificadoCompetencia(DateTime competencia)
    {
        var valorSimplificado = await _simplificado.ValorSimplificadoCompetencia(competencia);
        return valorSimplificado;
    }
}
