using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class DependenteRepository(AppDbContext _appDbContext) : IDependenteRepository
{
    public async Task<Dependente?> CreateAsync(Dependente dependente, CancellationToken cancellationToken = default)
    {
        await _appDbContext.AddAsync(dependente, cancellationToken);
        return dependente;
    }

    public async Task<Dependente?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dependente = await GetByIdAsync(id, cancellationToken);
        if (dependente is null)
        {
            return null;
        }
        _appDbContext.Remove(dependente);
        return dependente;
    }

    public async Task<IEnumerable<Dependente?>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Dependentes
                                  .AsNoTracking()
                                  .OrderBy(o => o.Competence)
                                  .Skip((page - 1) * size)
                                  .Take(size)
                                  .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Dependente?>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Dependentes
                                  .AsNoTracking()
                                  .OrderBy(o => o.Competence)
                                  .Where(w => w.Competence == competence)
                                  .ToListAsync(cancellationToken);
    }

    public async Task<Dependente?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dependente = await _appDbContext.Dependentes
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        if (dependente is null)
        {
            return null;
        }
        return dependente;
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Dependentes.CountAsync(cancellationToken);
    }

    public async Task<decimal> GetValueByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var value = await _appDbContext.Dependentes
                                       .AsNoTracking()
                                       .Where(w => w.Competence == competence)
                                       .Select(s => s.Value)
                                       .FirstOrDefaultAsync(cancellationToken);
        return value;
    }

    public async Task<Dependente?> UpdateAsync(Dependente dependente, CancellationToken cancellationToken = default)
    {
        var dependenteCurrent = await GetByIdAsync(dependente.Id, cancellationToken);
        if (dependenteCurrent is null)
        {
            return null;
        }
        _appDbContext.Update(dependenteCurrent);
        return dependente;
    }
}
