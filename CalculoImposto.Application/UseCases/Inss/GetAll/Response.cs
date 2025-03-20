namespace CalculoImposto.Application.UseCases.Inss.GetAll;

public sealed record Response(IEnumerable<Domain.Entities.Inss> InssList);
