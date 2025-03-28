namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface IDependenteRepository
{
    Task<IEnumerable<Entities.Dependente?>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default);
    Task<IEnumerable<Entities.Dependente?>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<Entities.Dependente?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Entities.Dependente?> CreateAsync(Entities.Dependente dependente, CancellationToken cancellationToken = default);
    Task<Entities.Dependente?> UpdateAsync(Entities.Dependente dependente, CancellationToken cancellationToken = default);
    Task<Entities.Dependente?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<decimal> GetValueByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(CancellationToken cancellationToken = default);
}
