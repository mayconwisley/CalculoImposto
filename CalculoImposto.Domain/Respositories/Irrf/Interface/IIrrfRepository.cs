namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface IIrrfRepository
{

    Task<int> GetRange(DateTime competence, decimal valueGross);
    Task<decimal> PercentRangeCompetence(DateTime competence, int range);
    Task<decimal> DeductionRangeCompetence(DateTime competence, int range);
    Task<decimal> ValueRangeCompetence(DateTime competence, int range);
    Task<int> Total();

    Task<IEnumerable<Entities.Irrf>> GetByCompetence(DateTime competence);
    Task<IEnumerable<Entities.Irrf>> GetAll(int page, int size);
    Task<Entities.Irrf> GetById(int id);
    Task<Entities.Irrf> Create(Entities.Irrf irrf);
    Task<Entities.Irrf> Update(Entities.Irrf irrf);
    Task<Entities.Irrf> Delete(int id);
}
