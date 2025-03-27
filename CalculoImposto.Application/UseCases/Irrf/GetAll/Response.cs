using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.Irrf;

namespace CalculoImposto.Application.UseCases.Irrf.GetAll;

public sealed record Response(PagedResult<IrrfDto> IrrfDtoResult);
