using CalculoImposto.API.Model.INSS;
using CalculoImposto.API.Model.IRRF;
using CalculoImposto.Modelo.DTO.INSS;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.MapeamentoDto.IrrfDto;

public  static class IRRFMapeamentoDto
{
    public static IEnumerable<IRRFDto> ConverterIrrfParaDtos(this IEnumerable<IRRFModel> irrf)
    {
        return (from irr in irrf
                select new IRRFDto
                {
                    Id = irr.Id,
                    Competencia = irr.Competencia,
                    Faixa = irr.Faixa,
                    Porcentagem = irr.Porcentagem,
                    Valor = irr.Valor

                }).ToList();
    }
    public static IEnumerable<IRRFModel> ConverterDtosParaIrrf(this IEnumerable<IRRFDto> irrf)
    {
        return (from irr in irrf
                select new IRRFModel
                {
                    Id = irr.Id,
                    Competencia = irr.Competencia,
                    Faixa = irr.Faixa,
                    Porcentagem = irr.Porcentagem,
                    Valor = irr.Valor

                }).ToList();
    }
    public static IRRFModel ConverteDtoParaIrrf(this IRRFDto irrf)
    {
        return new IRRFModel
        {
            Id = irrf.Id,
            Competencia = irrf.Competencia,
            Faixa = irrf.Faixa,
            Porcentagem = irrf.Porcentagem,
            Valor = irrf.Valor
        };
    }
    public static IRRFDto ConverteIrrfParaDto(this IRRFModel irrf)
    {
        return new IRRFDto
        {
            Id = irrf.Id,
            Competencia = irrf.Competencia,
            Faixa = irrf.Faixa,
            Porcentagem = irrf.Porcentagem,
            Valor = irrf.Valor
        };
    }
}
