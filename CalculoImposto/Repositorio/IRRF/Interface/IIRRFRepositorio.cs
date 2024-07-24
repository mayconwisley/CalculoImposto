using CalculoImposto.API.CRUD.Interface;
using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface IIrrfRepositorio : ICrudBase<IrrfModel>
{
    Task<IEnumerable<IrrfModel>> PegarPorCompetenciaIrrf(DateTime competencia);
    Task<int> TotalIrrf();
    Task<int> PegarFaixaIrrf(DateTime competencia, decimal valorBrutoIrrf);
    Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa);
}
