using CalculoImposto.API.Model.IRRF;

namespace CalculoImposto.API.Repositorio.IRRF.Interface;

public interface IIRRFRepositorio
{
    Task<IEnumerable<IRRFModel>> PegarTodosIrrf(int pagina, int tamanho, string busca);
    Task<IRRFModel> PegarPorIdIrrf(int id);
    Task<IRRFModel> CriarIrrf(IRRFModel irrf);
    Task<IRRFModel> AtualizarIrrf(IRRFModel irrf);
    Task<IRRFModel> DeletarIrrf(int id);
    Task<int> TotalIrrf();
    Task<int> PegarFaixaIrrf(DateTime competencia, decimal valorBrutoIrrf);
    Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa);
}
