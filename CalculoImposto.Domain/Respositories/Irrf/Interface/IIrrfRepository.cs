namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface IIrrfRepository
{
    Task<IEnumerable<Entities.Irrf>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default);
    Task<IEnumerable<Entities.Irrf>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<Entities.Irrf> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> GetRangeByCompetenceAndBaseInssAsync(DateTime competence, decimal valueGross, CancellationToken cancellationToken = default);
    Task<decimal> GetPercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default);
    Task<decimal> GetDeductionRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default);
    Task<decimal> GetValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    Task<Entities.Irrf> CreateAsync(Entities.Irrf irrf, CancellationToken cancellationToken = default);
    Task<Entities.Irrf> UpdateAsync(Entities.Irrf irrf, CancellationToken cancellationToken = default);
    Task<Entities.Irrf> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
