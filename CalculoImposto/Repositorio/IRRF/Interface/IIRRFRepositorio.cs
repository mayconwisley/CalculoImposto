using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface IIrrfRepositorio
{
    Task<IEnumerable<IrrfModel>> PegarTodosIrrf(int pagina, int tamanho, string busca);
    Task<IrrfModel> PegarPorIdIrrf(int id);
    Task<IEnumerable<IrrfModel>> PegarPorCompetenciaIrrf(DateTime competencia);
    Task<IrrfModel> CriarIrrf(IrrfModel irrf);
    Task<IrrfModel> AtualizarIrrf(IrrfModel irrf);
    Task<IrrfModel> DeletarIrrf(int id);
    Task<int> TotalIrrf();
    Task<int> PegarFaixaIrrf(DateTime competencia, decimal valorBrutoIrrf);
    Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa);
}
