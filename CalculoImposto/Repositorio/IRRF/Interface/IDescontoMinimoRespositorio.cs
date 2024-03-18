using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface IDescontoMinimoRespositorio
{
    Task<IEnumerable<DescontoMinimoModel>> PegarTodosDescontoMinimo(int pagina, int tamanho, string busca);
    Task<DescontoMinimoModel> PegarPorIdDescontoMinimo(int id);
    Task<DescontoMinimoModel> CriarDescontoMinimo(DescontoMinimoModel descontoMinimo);
    Task<DescontoMinimoModel> AtualizarDescontoMinimo(DescontoMinimoModel descontoMinimo);
    Task<DescontoMinimoModel> DeletarDescontoMinimo(int id);
    Task<decimal> ValorDescontoMinimoCompetencia(DateTime competencia);
    Task<int> TotalDescontoMinimo();
}
