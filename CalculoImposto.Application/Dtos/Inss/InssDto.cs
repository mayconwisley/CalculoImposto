namespace CalculoImposto.Application.Dtos.Inss;

public record InssDto(Guid Id = default, int Range = 1, decimal Percent = 7.5m, DateTime Competence = new DateTime(), decimal Value = 0m);
