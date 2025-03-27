using CalculoImposto.Application.Dtos.Irrf;

namespace CalculoImposto.Application.UseCases.Irrf.GetByCompetence;

public sealed record Response(IEnumerable<IrrfDto> IrrfDtoList);
