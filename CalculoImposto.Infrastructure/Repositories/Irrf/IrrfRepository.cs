using CalculoImposto.Domain.Respositories.Irrf.Interface;

namespace CalculoImposto.Infrastructure.Repositories.Irrf;

public class IrrfRepository : IIrrfRepository
{
    public Task<Domain.Entities.Irrf> Create(Domain.Entities.Irrf irrf)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> DeductionRangeCompetence(DateTime competence, int range)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Irrf> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.Irrf>> GetAll(int page, int size)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.Irrf>> GetByCompetence(DateTime competence)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Irrf> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetRange(DateTime competence, decimal valueGross)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> PercentRangeCompetence(DateTime competence, int range)
    {
        throw new NotImplementedException();
    }

    public Task<int> Total()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Irrf> Update(Domain.Entities.Irrf irrf)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> ValueRangeCompetence(DateTime competence, int range)
    {
        throw new NotImplementedException();
    }
}
