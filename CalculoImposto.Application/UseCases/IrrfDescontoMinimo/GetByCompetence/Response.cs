using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.GetByCompetence;

public sealed record Response(IEnumerable<DescontoMinimoDto> DescontoMinimoDtoList);
