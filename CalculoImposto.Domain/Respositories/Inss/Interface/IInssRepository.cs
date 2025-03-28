namespace CalculoImposto.Domain.Respositories.Inss.Interface;

public interface IInssRepository
{
    Task<IEnumerable<Entities.Inss?>> GetAllAsync(int page = 0, int size = 25, CancellationToken cancellationToken = default);
    Task<IEnumerable<Entities.Inss?>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<Entities.Inss?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> GetRangeByCompetenceAndBaseInssAsync(DateTime competence, decimal baseInss, CancellationToken cancellationToken = default);
    Task<int> GetLastRangeCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<decimal> GetPercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default);
    Task<decimal> GetValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default);
    Task<decimal> GetValueRoofCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> GetTotalRangeAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    Task<Entities.Inss?> CreateAsync(Entities.Inss inss, CancellationToken cancellationToken = default);
    Task<Entities.Inss?> UpdateAsync(Entities.Inss inss, CancellationToken cancellationToken = default);
    Task<Entities.Inss?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
