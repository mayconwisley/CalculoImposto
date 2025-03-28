using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.GetAll;

public sealed record Response(PagedResult<DescontoMinimoDto> DescontoMinimoDtoResult);
