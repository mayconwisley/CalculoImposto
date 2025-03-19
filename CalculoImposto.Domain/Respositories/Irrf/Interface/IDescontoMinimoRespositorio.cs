namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface IDescontoMinimoRespositorio
{
    Task<decimal> ValueCompetence(DateTime competencia);
    Task<int> Total();

    Task<IEnumerable<Entities.DescontoMinimo>> GetAll(int page, int size, string search);
    Task<Entities.DescontoMinimo> GetByCompetence(DateTime competence);
    Task<Entities.DescontoMinimo> GetById(int id);
    Task<Entities.DescontoMinimo> Create(Entities.DescontoMinimo descontoMinimo);
    Task<Entities.DescontoMinimo> Update(Entities.DescontoMinimo descontoMinimo);
    Task<Entities.DescontoMinimo> Delete(int id);
}
