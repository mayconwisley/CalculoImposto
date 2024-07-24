using CalculoImposto.API.CRUD.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF.Interface;

public interface IIrrfServico : ICrudBase<IrrfDto>
{
    Task<IEnumerable<IrrfDto>> PegarPorCompetenciaIrrf(DateTime competencia);
    Task<int> TotalIrrf();
    Task<int> PegarFaixaIrrf(DateTime competencia, decimal baseIrrf);
    Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa);
}
