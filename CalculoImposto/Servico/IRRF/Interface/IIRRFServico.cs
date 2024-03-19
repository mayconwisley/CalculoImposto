using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF.Interface;

public interface IIRRFServico
{
    Task<IEnumerable<IRRFDto>> PegarTodosIrrf(int pagina, int tamanho, string busca);
    Task<IRRFDto> PegarPorIdIrrf(int id);
    Task CriarIrrf(IRRFDto irrf);
    Task AtualizarIrrf(IRRFDto irrf);
    Task DeletarIrrf(int id);
    Task<int> TotalIrrf();
    Task<int> PegarFaixaIrrf(DateTime competencia, decimal baseIrrf);
    Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa);
}
