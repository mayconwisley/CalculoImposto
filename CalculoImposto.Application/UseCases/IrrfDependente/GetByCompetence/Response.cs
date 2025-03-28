using CalculoImposto.Application.Dtos.IrrfDependente;

namespace CalculoImposto.Application.UseCases.IrrfDependente.GetByCompetence;

public sealed record Response(IEnumerable<DependenteDto> DependenteDtoList);
