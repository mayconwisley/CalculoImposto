using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF.Interface;

public interface IDescontoMinimoServico
{
    Task<IEnumerable<DescontoMinimoDto>> PegarTodosDescontoMinimo(int pagina, int tamanho, string busca);
    Task<DescontoMinimoDto> PegarPorCompetenciaDescontoMinimo(DateTime competencia);
    Task<DescontoMinimoDto> PegarPorIdDescontoMinimo(int id);
    Task CriarDescontoMinimo(DescontoMinimoDto descontoMinimo);
    Task AtualizarDescontoMinimo(DescontoMinimoDto descontoMinimo);
    Task DeletarDescontoMinimo(int id);
    Task<int> TotalDescontoMinimo();
    Task<decimal> ValorDescontoMinimoCompetencia(DateTime competencia);
}
