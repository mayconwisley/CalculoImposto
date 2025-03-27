namespace CalculoImposto.Application.Dtos.Irrf;

public record IrrfCreateDto(int Range, decimal Percent, decimal Deduction, DateTime Competence, decimal Value);

