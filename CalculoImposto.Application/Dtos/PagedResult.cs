namespace CalculoImposto.Application.Dtos;

public sealed record PagedResult<T>(IEnumerable<T> Data, int TotalItems, int PagesCounts, int PageNumber);
