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
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Domain.Entities.Inss>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Inss
                     .Where(w => w.Competencia == competence)
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
                    .Where(w => w.Valor >= baseInss &&
                                w.Competencia == _appDbContext.Inss
                                                .Where(w => w.Competencia <= competence)
                                                .Max(m => m.Competencia))
                    .MinAsync(m => m.Faixa, cancellationToken);
        return range;
    }

    public async Task<int> LastRangeCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var range = await _appDbContext.Inss
                    .Where(w => w.Competencia == competence)
                    .MaxAsync(m => m.Faixa, cancellationToken);
        return range;
    }

    public async Task<decimal> PercentRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var percentRange = await _appDbContext.Inss
                           .Where(w => w.Competencia == competence && w.Faixa == range)
                           .Select(s => s.Porcentagem)
                           .FirstOrDefaultAsync(cancellationToken);
        return percentRange;
    }

    public async Task<int> TotalRangeAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var totalRange = await _appDbContext.Inss
                         .Where(w => w.Competencia == competence)
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

    public async Task<decimal> ValueRangeCompetenceAsync(DateTime competence, int range, CancellationToken cancellationToken = default)
    {
        var valueRange = await _appDbContext.Inss
                         .Where(w => w.Faixa == range &&
                                     w.Competencia == _appDbContext.Inss
                                                      .Where(w => w.Competencia <= competence)
                                                      .Max(m => m.Competencia))
                         .Select(s => s.Valor)
                         .FirstOrDefaultAsync(cancellationToken);
        return valueRange;
    }

    public async Task<decimal> ValueRoofCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var valueRoof = await _appDbContext.Inss
                        .Where(w => w.Competencia == _appDbContext.Inss
                                                     .Where(w => w.Competencia <= competence)
                                                     .Max(m => m.Competencia))
                        .MaxAsync(m => m.Valor, cancellationToken);
        return valueRoof;
    }
}
