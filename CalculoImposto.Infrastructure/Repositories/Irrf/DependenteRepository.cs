using CalculoImposto.Domain.Entities;
using CalculoImposto.Domain.Respositories.Irrf.Interface;

namespace CalculoImposto.Infrastructure.Repositories.Irrf
{
    public class DependenteRepository : IDependenteRepository
    {
        public Task<Dependente> Create(Dependente dependente)
        {
            throw new NotImplementedException();
        }

        public Task<Dependente> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dependente>> GetAll(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<Dependente> GetByCompetence(DateTime competence)
        {
            throw new NotImplementedException();
        }

        public Task<Dependente> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> TotalDependent()
        {
            throw new NotImplementedException();
        }

        public Task<Dependente> Update(Dependente dependente)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> ValueDependent(DateTime competence)
        {
            throw new NotImplementedException();
        }
    }
}
