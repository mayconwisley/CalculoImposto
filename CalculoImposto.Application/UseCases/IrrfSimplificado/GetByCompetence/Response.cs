using CalculoImposto.Application.Dtos.IrrfSimplificado;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.GetByCompetence;

public sealed record Response(IEnumerable<SimplificadoDto> SimplificadoDtoList);
