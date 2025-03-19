namespace CalculoImposto.Domain.Respositories.Inss.Interface;

public interface IInssRepository
{
    Task<IEnumerable<Entities.Inss>> GetByCompetenceAsync(DateTime competence);
    Task<int> GetRange(DateTime competence, decimal baseInss);
    Task<int> LastRangeCompetence(DateTime competence);
    Task<decimal> PercentRangeCompetence(DateTime competence, int range);
    Task<decimal> ValueRangeCompetence(DateTime competence, int range);
    Task<decimal> ValueRoofCompetence(DateTime competence);
    Task<int> Total(string search);
    Task<IEnumerable<Entities.Inss>> GetAll(int page, int size);
    Task<Entities.Inss> GetById(int id);
    Task<Entities.Inss> Create(Entities.Inss inss);
    Task<Entities.Inss> Update(Entities.Inss inss);
    Task<Entities.Inss> Delete(int id);
}
