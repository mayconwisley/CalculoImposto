using CalculoImposto.Application.Dtos;

namespace CalculoImposto.Application.UseCases.Inss.GetAll;

public sealed record Response(PagedResult<Domain.Entities.Inss> InssResult);
