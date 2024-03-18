using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface IDependenteRepositorio
{
    Task<IEnumerable<DependenteModel>> PegarTodosDependente(int pagina, int tamanho, string busca);
    Task<DependenteModel> PegarPorCompetenciaDependente(DateTime competencia);
    Task<DependenteModel> PegarPorIdDependente(int id);
    Task<DependenteModel> CriarDependente(DependenteModel dependente);
    Task<DependenteModel> AtualizarDependente(DependenteModel dependente);
    Task<DependenteModel> DeletarDependente(int id);
    Task<decimal> ValorDependenteCompetencia(DateTime competencia);
    Task<int> TotalDependente();
}
