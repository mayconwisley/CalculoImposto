using CalculoImposto.Application.Dtos.Inss;

namespace CalculoImposto.Application.UseCases.Inss.GetByCompetence;

public sealed record Response(IEnumerable<InssDto> InssDtoList);
