﻿namespace CalculoImposto.Domain.Respositories.Inss.Interface;

public interface IInssRepository
{
    Task<IEnumerable<Entities.Inss>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> GetRangeAsync(DateTime competence, decimal baseInss, CancellationToken cancellationToken = default);
    Task<int> LastRangeCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<decimal> PercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default);
    Task<decimal> ValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default);
    Task<decimal> ValueRoofCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> TotalAsync(string search, CancellationToken cancellationToken = default);
    Task<IEnumerable<Entities.Inss>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default);
    Task<Entities.Inss> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Entities.Inss> CreateAsync(Entities.Inss inss, CancellationToken cancellationToken = default);
    Task<Entities.Inss> UpdateAsync(Entities.Inss inss, CancellationToken cancellationToken = default);
    Task<Entities.Inss> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
