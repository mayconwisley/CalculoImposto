using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface IIRRFRepositorio
{
    Task<IEnumerable<IRRFModel>> PegarTodosIrrf(int pagina, int tamanho, string busca);
    Task<IEnumerable<DependenteModel>> PegarTodosDependente(int pagina, int tamanho, string busca);
    Task<IEnumerable<DescontoMinimoModel>> PegarTodosDescontoMinimo(int pagina, int tamanho, string busca);
    Task<IEnumerable<SimplificadoModel>> PegarTodosSimplificado(int pagina, int tamanho, string busca);

    Task<IRRFModel> PegarPorIdIrrf(int id);
    Task<DependenteModel> PegarPorIdDependente(int id);
    Task<DescontoMinimoModel> PegarPorIdDescontoMinimo(int id);
    Task<SimplificadoModel> PegarPorIdSimplificado(int id);

    Task<IRRFModel> CriarIrrf(IRRFModel irrf);
    Task<DependenteModel> CriarDependente(DependenteModel dependente);
    Task<DescontoMinimoModel> CriarDescontoMinimo(DescontoMinimoModel descontoMinimo);
    Task<SimplificadoModel> CriarSimplificado(SimplificadoModel simplificado);

    Task<IRRFModel> AtualizarIrrf(IRRFModel irrf);
    Task<DependenteModel> AtualizarDependente(DependenteModel dependente);
    Task<DescontoMinimoModel> AtualizarDescontoMinimo(DescontoMinimoModel descontoMinimo);
    Task<SimplificadoModel> AtualizarSimplificado(SimplificadoModel simplificado);

    Task<IRRFModel> DeletarIrrf(int id);
    Task<DependenteModel> DeletarDependente(int id);
    Task<DescontoMinimoModel> DeletarDescontoMinimo(int id);
    Task<SimplificadoModel> DeletarSimplificado(int id);

    Task<int> TotalIrrf(string busca);
    Task<int> TotalDependente(string busca);
    Task<int> TotalDescontoMinimo(string busca);
    Task<int> TotalSimplificado(string busca);

}
