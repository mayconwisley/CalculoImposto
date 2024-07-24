using CalculoImposto.API.CRUD.Interface;
using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface IDependenteRepositorio : ICrudBase<DependenteModel>
{
    Task<DependenteModel> PegarPorCompetenciaDependente(DateTime competencia);
    Task<decimal> ValorDependenteCompetencia(DateTime competencia);
    Task<int> TotalDependente();
}
