namespace CalculoImposto.Application.Dtos;

public sealed record PagedResult<T>(IEnumerable<T> Items, int TotalItems, int TotalPages, int CurrentPage);
