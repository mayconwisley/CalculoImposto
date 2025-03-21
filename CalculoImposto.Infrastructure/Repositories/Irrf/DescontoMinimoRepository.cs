using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class DescontoMinimoRepository : IDescontoMinimoRespository
{
    public Task<DescontoMinimo> Create(DescontoMinimo descontoMinimo)
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DescontoMinimo>> GetAll(int page, int size, string search)
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> GetByCompetence(DateTime competence)
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Total()
    {
        throw new NotImplementedException();
    }

    public Task<DescontoMinimo> Update(DescontoMinimo descontoMinimo)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ValueCompetence(DateTime competencia)
    {
        throw new NotImplementedException();
    }
}
