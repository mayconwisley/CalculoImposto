namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface ISimplificadoRepository
{
    Task<IEnumerable<Entities.Simplificado?>> GetAllAsync(int page, int size, string search, CancellationToken cancellationToken = default);
    Task<IEnumerable<Entities.Simplificado?>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<Entities.Simplificado?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Entities.Simplificado?> CreateAsync(Entities.Simplificado simplificado, CancellationToken cancellationToken = default);
    Task<Entities.Simplificado?> UpdateAsync(Entities.Simplificado simplificado, CancellationToken cancellationToken = default);
    Task<Entities.Simplificado?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<decimal> GetValueCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(CancellationToken cancellationToken = default);

}
