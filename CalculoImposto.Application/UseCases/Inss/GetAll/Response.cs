using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.Inss;

namespace CalculoImposto.Application.UseCases.Inss.GetAll;

public sealed record Response(PagedResult<InssDto> InssDtoResult);
