using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.IrrfDependente;

namespace CalculoImposto.Application.UseCases.IrrfDependente.GetAll;

public sealed record Response(PagedResult<DependenteDto> DependenteDtoResult);
