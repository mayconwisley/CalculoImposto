namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface IDependenteRepository
{
    Task<decimal> ValueDependent(DateTime competence);
    Task<int> TotalDependent();

    Task<IEnumerable<Entities.Dependente>> GetAll(int page, int size);
    Task<Entities.Dependente> GetByCompetence(DateTime competence);
    Task<Entities.Dependente> GetById(int id);
    Task<Entities.Dependente> Create(Entities.Dependente dependente);
    Task<Entities.Dependente> Update(Entities.Dependente dependente);
    Task<Entities.Dependente> Delete(int id);
}
