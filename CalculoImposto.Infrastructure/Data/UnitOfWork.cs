using CalculoImposto.Domain.Abstractions;

namespace CalculoImposto.Infrastructure.Data;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    public async Task CommitAsynk() => await appDbContext.SaveChangesAsync();

}
