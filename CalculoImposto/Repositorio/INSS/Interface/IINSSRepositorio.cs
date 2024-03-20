using CalculoImposto.API.Model.INSS;

namespace CalculoImposto.API.Repositorio.INSS.Interface;

public interface IInssRepositorio
{
    Task<IEnumerable<InssModel>> PegarTodosInss(int pagina, int tamanho, string busca);
    Task<IEnumerable<InssModel>> PegarTodosPorCompetenciaInss(DateTime competencia);

    Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss);
    Task<int> UltimaFaixaCompetenciaInss(DateTime competencia);

    Task<decimal> PorcentagemFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorTetoCompetenciaInss(DateTime competencia);

    Task<InssModel> PegarPorIdInss(int id);
    Task<InssModel> CriarInss(InssModel inss);
    Task<InssModel> AtualizarInss(InssModel inss);
    Task<InssModel> DeletarInss(int id);

    Task<int> TotalInss(string busca);
}
