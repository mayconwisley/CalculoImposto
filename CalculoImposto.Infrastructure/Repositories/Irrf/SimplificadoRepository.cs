using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class SimplificadoRepository : ISimplificadoRepository
{
    public Task<Simplificado> Create(Simplificado simplificado)
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Simplificado>> GetAll(int page, int size, string search)
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> GetByCompetence(DateTime competence)
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Total()
    {
        throw new NotImplementedException();
    }

    public Task<Simplificado> Update(Simplificado simplificado)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ValueCompetence(DateTime competence)
    {
        throw new NotImplementedException();
    }
}
