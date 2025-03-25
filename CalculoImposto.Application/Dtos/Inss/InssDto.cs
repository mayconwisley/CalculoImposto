namespace CalculoImposto.Application.Dtos.Inss;

public record InssDto(Guid Id, int Range, decimal Dercent, DateTime Competence, decimal Value);
