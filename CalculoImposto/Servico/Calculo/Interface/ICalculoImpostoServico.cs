using CalculoImposto.Modelo.DTO.INSS;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.Calculo.Interface;

public interface ICalculoImpostoServico
{
    Task<CalculoInssProgressivoDto> CalculoInssProgressivo(DateTime competencia, decimal baseInss);
    Task<CalculoSimplificadoDto> CalculoIrrfSimplificado(DateTime competencia, decimal valorBrutoIrrf);
    Task<CalculoNormalDto> CalculoIrrfNormal(DateTime competencia, decimal valorBruto, decimal valorBrutoIrrf, int qtdDependete);
    Task<CalculoProgressivoDto> CalculoIrrfProgressivo(DateTime competencia, decimal valorBruto, decimal valorBrutoIrrf, int qtdDependete);
}
