using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF.Interface;

public interface IDependenteServico
{
    Task<IEnumerable<DependenteDto>> PegarTodosDependente(int pagina, int tamanho, string busca);
    Task<DependenteDto> PegarPorCompetenciaDependente(DateTime competencia);
    Task<DependenteDto> PegarPorIdDependente(int id);
    Task CriarDependente(DependenteDto dependente);
    Task AtualizarDependente(DependenteDto dependente);
    Task DeletarDependente(int id);
    Task<int> TotalDependente();
    Task<decimal> ValorDependenteCompetencia(DateTime competencia);
}
