using CalculoImposto.API.MapeamentoDto.IrrfDto;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF;

public class DescontoMinimoServico(IDescontoMinimoRespositorio descontoMinimo) : IDescontoMinimoServico
{
    private readonly IDescontoMinimoRespositorio _descontoMinimo = descontoMinimo;

    public async Task AtualizarDescontoMinimo(DescontoMinimoDto descontoMinimo)
    {
        await _descontoMinimo.AtualizarDescontoMinimo(descontoMinimo.ConverterDtoParaDescontoMinimo());
    }

    public async Task CriarDescontoMinimo(DescontoMinimoDto descontoMinimo)
    {
        await _descontoMinimo.CriarDescontoMinimo(descontoMinimo.ConverterDtoParaDescontoMinimo());
    }

    public async Task DeletarDescontoMinimo(int id)
    {
        var descontoMinimo = await _descontoMinimo.PegarPorIdDescontoMinimo(id);
        if (descontoMinimo is not null)
        {
            await _descontoMinimo.DeletarDescontoMinimo(descontoMinimo.Id);
        }
    }

    public async Task<DescontoMinimoDto> PegarPorIdDescontoMinimo(int id)
    {
        var descontoMinimo = await _descontoMinimo.PegarPorIdDescontoMinimo(id);
        return descontoMinimo.ConverterDescontoMinimoParaDto();
    }

    public async Task<IEnumerable<DescontoMinimoDto>> PegarTodosDescontoMinimo(int pagina, int tamanho, string busca)
    {
        var descontoMinimoList = await _descontoMinimo.PegarTodosDescontoMinimo(pagina, tamanho, busca);
        return descontoMinimoList.ConverterDescontosMinimosParaDtos();
    }

    public async Task<int> TotalDescontoMinimo()
    {
        var totalDescontoMinimo = await _descontoMinimo.TotalDescontoMinimo();
        return totalDescontoMinimo;
    }

    public async Task<decimal> ValorDescontoMinimoCompetencia(DateTime competencia)
    {
        var descontoMinimo = await _descontoMinimo.ValorDescontoMinimoCompetencia(competencia);
        return descontoMinimo;
    }
}
