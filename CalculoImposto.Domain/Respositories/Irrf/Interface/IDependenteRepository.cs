namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface IDependenteRepository
{
    Task<IEnumerable<Entities.Dependente>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default);
    Task<Entities.Dependente> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<Entities.Dependente> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<decimal> GetValueDependentAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> GetTotalDependentAsync(CancellationToken cancellationToken = default);
    Task<Entities.Dependente> CreateAsync(Entities.Dependente dependente, CancellationToken cancellationToken = default);
    Task<Entities.Dependente> UpdateAsync(Entities.Dependente dependente, CancellationToken cancellationToken = default);
    Task<Entities.Dependente> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
