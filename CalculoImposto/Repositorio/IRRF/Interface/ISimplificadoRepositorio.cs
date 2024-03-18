using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface ISimplificadoRepositorio
{
    Task<IEnumerable<SimplificadoModel>> PegarTodosSimplificado(int pagina, int tamanho, string busca);
    Task<SimplificadoModel> PegarPorIdSimplificado(int id);
    Task<SimplificadoModel> CriarSimplificado(SimplificadoModel simplificado);
    Task<SimplificadoModel> AtualizarSimplificado(SimplificadoModel simplificado);
    Task<SimplificadoModel> DeletarSimplificado(int id);
    Task<decimal> ValorSimplificadoCompetencia(DateTime competencia);
    Task<int> TotalSimplificado();
}
