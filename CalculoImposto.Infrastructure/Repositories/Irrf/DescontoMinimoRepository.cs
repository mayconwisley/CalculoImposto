using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using CalculoImposto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class DescontoMinimoRepository(AppDbContext _appDbContext) : IDescontoMinimoRespository
{
    public async Task<DescontoMinimo?> CreateAsync(DescontoMinimo descontoMinimo, CancellationToken cancellationToken = default)
    {
        await _appDbContext.AddAsync(descontoMinimo, cancellationToken);
        return descontoMinimo;
    }

    public async Task<DescontoMinimo?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var descontoMinimo = await GetByIdAsync(id, cancellationToken);
        if (descontoMinimo is null)
        {
            return null;
        }
        _appDbContext.Remove(descontoMinimo);
        return descontoMinimo;
    }

    public async Task<IEnumerable<DescontoMinimo?>> GetAllAsync(int page, int size, string search, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.DescontoMinimos
                                  .AsNoTracking()
                                  .Where(w => w.Competence.ToString()
                                                          .ToLower()
                                                          .Contains(search.ToLower()))
                                  .OrderBy(o => o.Competence)
                                  .Skip((page - 1) * size)
                                  .Take(size)
                                  .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<DescontoMinimo?>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.DescontoMinimos
                                  .AsNoTracking()
                                  .OrderBy(o => o.Competence)
                                  .Where(w => w.Competence == competence)
                                  .ToListAsync(cancellationToken);
    }

    public async Task<DescontoMinimo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var descontoMinimo = await _appDbContext.DescontoMinimos
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        if (descontoMinimo is null)
        {
            return null;
        }
        return descontoMinimo;
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.DescontoMinimos.CountAsync(cancellationToken);
    }

    public async Task<DescontoMinimo?> UpdateAsync(DescontoMinimo descontoMinimo, CancellationToken cancellationToken = default)
    {
        var descontoMinimoCurrent = await GetByIdAsync(descontoMinimo.Id, cancellationToken);
        if (descontoMinimoCurrent is null)
        {
            return null;
        }
        _appDbContext.Update(descontoMinimoCurrent);
        return descontoMinimo;
    }

    public async Task<decimal> ValueCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default)
    {
        var value = await _appDbContext.DescontoMinimos
                                       .AsNoTracking()
                                       .Where(w => w.Competence == competence)
                                       .Select(s => s.Value)
                                       .FirstOrDefaultAsync(cancellationToken);
        return value;
    }
}
