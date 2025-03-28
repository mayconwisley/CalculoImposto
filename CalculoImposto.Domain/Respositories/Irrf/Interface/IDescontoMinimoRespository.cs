namespace CalculoImposto.Domain.Respositories.Irrf.Interface;

public interface IDescontoMinimoRespository
{
    Task<IEnumerable<Entities.DescontoMinimo?>> GetAllAsync(int page, int size, string search, CancellationToken cancellationToken = default);
    Task<IEnumerable<Entities.DescontoMinimo?>> GetByCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<Entities.DescontoMinimo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Entities.DescontoMinimo?> CreateAsync(Entities.DescontoMinimo descontoMinimo, CancellationToken cancellationToken = default);
    Task<Entities.DescontoMinimo?> UpdateAsync(Entities.DescontoMinimo descontoMinimo, CancellationToken cancellationToken = default);
    Task<Entities.DescontoMinimo?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<decimal> ValueCompetenceAsync(DateTime competence, CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(CancellationToken cancellationToken = default);
}
