namespace CalculoImposto.Application.Dtos.Inss;

public record InssCreateDto(int Range, decimal Percent, DateTime Competence, decimal Value);
