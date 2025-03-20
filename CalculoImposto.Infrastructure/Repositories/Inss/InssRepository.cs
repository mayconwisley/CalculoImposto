using CalculoImposto.Domain.Respositories.Inss.Interface;
using CalculoImposto.Infrastructure.Data;

namespace CalculoImposto.Infrastructure.Repositories.Inss;

public class InssRepository(AppDbContext _appDbContext) : IInssRepository
{
    public async Task<Domain.Entities.Inss> CreateAsync(Domain.Entities.Inss inss, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Inss.AddAsync(inss, cancellationToken);
        return inss;
    }

    public async Task<Domain.Entities.Inss> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var inss = await GetByIdAsync(id, cancellationToken);
        if (inss is null)
        {
            return null;
        }

        _appDbContext.Remove(inss);
        return inss;
    }

    public Task<IEnumerable<Domain.Entities.Inss>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.Inss>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Inss> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetRangeAsync(DateTime competence, decimal baseInss, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> LastRangeCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> PercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> TotalAsync(string search, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Entities.Inss> UpdateAsync(Domain.Entities.Inss inss, CancellationToken cancellationToken = default)
    {
        var inssCurrent = await GetByIdAsync(inss.Id, cancellationToken);
        if (inssCurrent is null)
        {
            return null;
        }

        _appDbContext.Update(inss);
        return inss;
    }

    public Task<decimal> ValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ValueRoofCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
