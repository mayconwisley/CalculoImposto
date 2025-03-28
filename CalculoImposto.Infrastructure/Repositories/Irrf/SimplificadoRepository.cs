using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class SimplificadoRepository(AppDbContext _appDbContext) : ISimplificadoRepository
{
    public async Task<Simplificado?> CreateAsync(Simplificado simplificado, CancellationToken cancellationToken = default)
    {
        await _appDbContext.AddAsync(simplificado, cancellationToken);
        return simplificado;
    }
    public async Task<Simplificado?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var simplificado = await GetByIdAsync(id, cancellationToken);
        if (simplificado is null)
        {
            return null;
        }
        _appDbContext.Remove(simplificado);
        return simplificado;
    }
    public async Task<IEnumerable<Simplificado?>> GetAllAsync(int page, int size, string search, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Simplificados
                                  .AsNoTracking()
                                  .OrderBy(o => o.Competence)
                                  .Skip((page - 1) * size)
                                  .Take(size)
                                  .ToListAsync(cancellationToken);
    }
    public async Task<IEnumerable<Simplificado?>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Simplificados
                                  .AsNoTracking()
                                  .OrderBy(o => o.Competence)
                                  .Where(w => w.Competence == competence)
                                  .ToListAsync(cancellationToken);
    }
    public async Task<Simplificado?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var simplificado = await _appDbContext.Simplificados
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        if (simplificado is null)
        {
            return null;
        }
        return simplificado;
    }
    public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Simplificados.CountAsync(cancellationToken);
    }
    public async Task<decimal> GetValueCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var value = await _appDbContext.Simplificados
                                       .AsNoTracking()
                                       .Where(w => w.Competence == competence)
                                       .Select(s => s.Value)
                                       .FirstOrDefaultAsync(cancellationToken);
        return value;
    }
    public async Task<Simplificado?> UpdateAsync(Simplificado simplificado, CancellationToken cancellationToken = default)
    {
        var simplificadoCurrent = await GetByIdAsync(simplificado.Id, cancellationToken);
        if (simplificadoCurrent is null)
        {
            return null;
        }
        _appDbContext.Update(simplificadoCurrent);
        return simplificado;
    }
}
