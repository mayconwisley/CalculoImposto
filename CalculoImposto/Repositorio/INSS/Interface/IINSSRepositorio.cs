using CalculoImposto.API.Model.INSS;

namespace CalculoImposto.API.Repositorio.INSS.Interface;

public interface IINSSRepositorio
{
    Task<IEnumerable<INSSModel>> PegarTodosInss(int pagina, int tamanho, string busca);
    Task<IEnumerable<INSSModel>> PegarTodosPorCompetenciaInss(DateTime competencia);
    
    Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss);
    Task<int> UltimaFaixaCompetenciaInss(DateTime competencia);

    Task<decimal> PorcentagemFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorTetoCompetenciaInss(DateTime competencia);

    Task<INSSModel> PegarPorIdInss(int id);
    Task<INSSModel> CriarInss(INSSModel inss);
    Task<INSSModel> AtualizarInss(INSSModel inss);
    Task<INSSModel> DeletarInss(int id);
    
    Task<int> TotalInss(string busca);
}
