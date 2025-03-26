namespace CalculoImposto.Application.Dtos.Inss;

public record InssDto(Guid Id, int Range, decimal Percent, DateTime Competence, decimal Value);
