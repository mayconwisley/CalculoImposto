using CalculoImposto.API.CRUD.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF.Interface;

public interface IDependenteServico : ICrudBase<DependenteDto>
{
    Task<DependenteDto> PegarPorCompetenciaDependente(DateTime competencia);
    Task<int> TotalDependente();
    Task<decimal> ValorDependenteCompetencia(DateTime competencia);
}
