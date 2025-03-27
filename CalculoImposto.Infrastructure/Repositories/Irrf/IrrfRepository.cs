using CalculoImposto.Domain.Respositories.Irrf.Interface;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class IrrfRepository(AppDbContext _appDbContext) : IIrrfRepository
{
    public async Task<Domain.Entities.Irrf> CreateAsync(Domain.Entities.Irrf irrf, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Irrf.AddAsync(irrf, cancellationToken);
        return irrf;
    }
    public async Task<decimal> GetDeductionRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var valueDeduction = await _appDbContext.Irrf
                              .AsNoTracking()
                              .Where(w => w.Range == range &&
                                          w.Competence == _appDbContext.Irrf
                                                          .Where(w => w.Competence <= competence)
                                                          .Max(m => m.Competence))
                              .Select(s => s.Deduction)
                              .FirstOrDefaultAsync(cancellationToken);
        return valueDeduction;
    }
    public async Task<Domain.Entities.Irrf> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var irrf = await GetByIdAsync(id, cancellationToken);
        if (irrf is null)
        {
            return new();
        }

        _appDbContext.Remove(irrf);
        return irrf;
    }
    public async Task<IEnumerable<Domain.Entities.Irrf>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default)
    {
        if (page < 1) page = 1;
        if (size < 1) size = 25;

        return await _appDbContext.Irrf
                     .AsNoTracking()
                     .OrderBy(o => o.Competence)
                     .ThenBy(o => o.Range)
                     .Skip((page - 1) * size)
                     .Take(size)
                     .ToListAsync(cancellationToken);
    }
    public async Task<IEnumerable<Domain.Entities.Irrf>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Irrf
                    .AsNoTracking()
                    .OrderBy(o => o.Range)
                    .Where(w => w.Competence == competence)
                    .ToListAsync(cancellationToken);
    }
    public async Task<Domain.Entities.Irrf> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var irrf = await _appDbContext.Irrf
                    .AsNoTracking()
                    .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        if (irrf is null)
        {
            return new();
        }
        return irrf;
    }
    public async Task<int> GetRangeByCompetenceAndBaseInssAsync(DateTime competence, decimal valueGross, CancellationToken cancellationToken = default)
    {
        var range = await _appDbContext.Irrf
                           .AsNoTracking()
                           .Where(w => w.Value >= valueGross &&
                                       w.Competence == _appDbContext.Irrf
                                                       .Where(w => w.Competence <= competence)
                                                       .Max(m => m.Competence))
                           .MinAsync(m => m.Range, cancellationToken);
        return range;
    }
    public async Task<decimal> GetPercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var percentRange = await _appDbContext.Irrf
                                 .AsNoTracking()
                                 .Where(w => w.Competence == competence && w.Range == range)
                                 .Select(s => s.Percent)
                                 .FirstOrDefaultAsync(cancellationToken);
        return percentRange;
    }
    public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Irrf
                     .AsNoTracking()
                     .CountAsync(cancellationToken);
    }
    public async Task<Domain.Entities.Irrf> UpdateAsync(Domain.Entities.Irrf irrf, CancellationToken cancellationToken = default)
    {
        var irrfCurrent = await GetByIdAsync(irrf.Id, cancellationToken);
        if (irrfCurrent is null)
        {
            return new();
        }
        _appDbContext.Irrf.Update(irrf);
        return irrf;
    }
    public async Task<decimal> GetValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var valueRange = await _appDbContext.Irrf
                               .AsNoTracking()
                               .Where(w => w.Range == range &&
                                           w.Competence == _appDbContext.Irrf
                                                           .Where(w => w.Competence <= competence)
                                                           .Max(m => m.Competence))
                               .Select(s => s.Value)
                               .FirstOrDefaultAsync(cancellationToken);
        return valueRange;
    }
}
