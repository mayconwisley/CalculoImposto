namespace CalculoImposto.Application.UseCases.Inss.GetByCompetence;

public sealed record Response(IEnumerable<Domain.Entities.Inss> InssList);
