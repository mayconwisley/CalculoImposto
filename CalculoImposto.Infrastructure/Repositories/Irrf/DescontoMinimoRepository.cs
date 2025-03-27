using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class DescontoMinimoRepository : IDescontoMinimoRespository
{
    public Task<DescontoMinimo> CreateAsync(DescontoMinimo descontoMinimo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DescontoMinimo>> GetAllAsync(int page, int size, string search, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> UpdateAsync(DescontoMinimo descontoMinimo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ValueCompetenceAsync(DateTime competencia, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
