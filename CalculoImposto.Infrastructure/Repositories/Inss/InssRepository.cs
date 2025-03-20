using CalculoImposto.Domain.Respositories.Inss.Interface;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            return new();
        }

        _appDbContext.Remove(inss);
        return inss;
    }

    public async Task<IEnumerable<Domain.Entities.Inss>> GetAllAsync(int page = 0, int size = 25, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Inss
                    .OrderBy(o => o.Competence)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Domain.Entities.Inss>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Inss
                     .OrderBy(o => o.Range)
                     .Where(w => w.Competence == competence)
                     .ToListAsync(cancellationToken);
    }

    public async Task<Domain.Entities.Inss> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var inss = await _appDbContext.Inss.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        if (inss is null)
        {
            return new();
        }
        return inss;
    }

    public async Task<int> GetRangeAsync(DateTime competence, decimal baseInss, CancellationToken cancellationToken = default)
    {
        var range = await _appDbContext.Inss
                    .Where(w => w.Value >= baseInss &&
                                w.Competence == _appDbContext.Inss
                                                .Where(w => w.Competence <= competence)
                                                .Max(m => m.Competence))
                    .MinAsync(m => m.Range, cancellationToken);
        return range;
    }

    public async Task<int> GetLastRangeCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var range = await _appDbContext.Inss
                    .Where(w => w.Competence == competence)
                    .MaxAsync(m => m.Range, cancellationToken);
        return range;
    }

    public async Task<decimal> GetPercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var percentRange = await _appDbContext.Inss
                           .Where(w => w.Competence == competence && w.Range == range)
                           .Select(s => s.Percent)
                           .FirstOrDefaultAsync(cancellationToken);
        return percentRange;
    }

    public async Task<int> GetTotalRangeAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var totalRange = await _appDbContext.Inss
                         .Where(w => w.Competence == competence)
                         .CountAsync(cancellationToken);
        return totalRange;
    }

    public async Task<Domain.Entities.Inss> UpdateAsync(Domain.Entities.Inss inss, CancellationToken cancellationToken = default)
    {
        var inssCurrent = await GetByIdAsync(inss.Id, cancellationToken);
        if (inssCurrent is null)
        {
            return new();
        }

        _appDbContext.Update(inss);
        return inss;
    }

    public async Task<decimal> GetValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var valueRange = await _appDbContext.Inss
                         .Where(w => w.Range == range &&
                                     w.Competence == _appDbContext.Inss
                                                      .Where(w => w.Competence <= competence)
                                                      .Max(m => m.Competence))
                         .Select(s => s.Value)
                         .FirstOrDefaultAsync(cancellationToken);
        return valueRange;
    }

    public async Task<decimal> GetValueRoofCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var valueRoof = await _appDbContext.Inss
                        .Where(w => w.Competence == _appDbContext.Inss
                                                     .Where(w => w.Competence <= competence)
                                                     .Max(m => m.Competence))
                        .MaxAsync(m => m.Value, cancellationToken);
        return valueRoof;
    }
}
