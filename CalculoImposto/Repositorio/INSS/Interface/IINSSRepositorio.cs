using CalculoImposto.API.CRUD.Interface;
using CalculoImposto.API.Model.INSS;

namespace CalculoImposto.API.Repositorio.INSS.Interface;

public interface IInssRepositorio : ICrudBase<InssModel>
{
    Task<IEnumerable<InssModel>> PegarTodosPorCompetenciaInss(DateTime competencia);
    Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss);
    Task<int> UltimaFaixaCompetenciaInss(DateTime competencia);
    Task<decimal> PorcentagemFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorTetoCompetenciaInss(DateTime competencia);
    Task<int> TotalInss(string busca);
}
