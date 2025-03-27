using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class DependenteRepository : IDependenteRepository
{
    public Task<Dependente> CreateAsync(Dependente dependente, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dependente> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Dependente>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dependente> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dependente> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalDependentAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetValueDependentAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Dependente> UpdateAsync(Dependente dependente, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
