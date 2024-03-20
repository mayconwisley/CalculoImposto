using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF.Interface;

public interface IIrrfServico
{
    Task<IEnumerable<IrrfDto>> PegarTodosIrrf(int pagina, int tamanho, string busca);
    Task<IEnumerable<IrrfDto>> PegarPorCompetenciaIrrf(DateTime competencia);
    Task<IrrfDto> PegarPorIdIrrf(int id);
    Task CriarIrrf(IrrfDto irrf);
    Task AtualizarIrrf(IrrfDto irrf);
    Task DeletarIrrf(int id);
    Task<int> TotalIrrf();
    Task<int> PegarFaixaIrrf(DateTime competencia, decimal baseIrrf);
    Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa);
}
