using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class SimplificadoRepository : ISimplificadoRepository
{
    public Task<Simplificado> CreateAsync(Simplificado simplificado, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Simplificado>> GetAllAsync(int page, int size, string search, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetValueCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> UpdateAsync(Simplificado simplificado, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
