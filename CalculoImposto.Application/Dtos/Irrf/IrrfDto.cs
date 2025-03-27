namespace CalculoImposto.Application.Dtos.Irrf;

public record IrrfDto(Guid Id, int Range, decimal Percent, decimal Deduction, DateTime Competence, decimal Value);
