namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface ISimplificadoRepositorio
{
    Task<IEnumerable<Entities.Simplificado>> GetAll(int page, int size, string search);
    Task<Entities.Simplificado> GetByCompetence(DateTime competence);
    Task<Entities.Simplificado> GetById(int id);
    Task<Entities.Simplificado> Create(Entities.Simplificado simplificado);
    Task<Entities.Simplificado> Update(Entities.Simplificado simplificado);
    Task<Entities.Simplificado> Delete(int id);
    Task<decimal> ValueCompetence(DateTime competence);
    Task<int> Total();
}
