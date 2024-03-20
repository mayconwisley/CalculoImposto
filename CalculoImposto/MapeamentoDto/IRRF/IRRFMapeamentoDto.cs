using CalculoImposto.API.Model.IRRF;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.MapeamentoDto.IRRF;

public static class IrrfMapeamentoDto
{
    public static IEnumerable<IrrfDto> ConverterIrrfParaDtos(this IEnumerable<IrrfModel> irrf)
    {
        return (from irr in irrf
                select new IrrfDto
                {
                    Id = irr.Id,
                    Competencia = irr.Competencia,
                    Faixa = irr.Faixa,
                    Porcentagem = irr.Porcentagem,
                    Valor = irr.Valor,
                    Deducao = irr.Deducao


                }).ToList();
    }
    public static IEnumerable<IrrfModel> ConverterDtosParaIrrf(this IEnumerable<IrrfDto> irrf)
    {
        return (from irr in irrf
                select new IrrfModel
                {
                    Id = irr.Id,
                    Competencia = irr.Competencia,
                    Faixa = irr.Faixa,
                    Porcentagem = irr.Porcentagem,
                    Valor = irr.Valor,
                    Deducao = irr.Deducao


                }).ToList();
    }
    public static IrrfModel ConverteDtoParaIrrf(this IrrfDto irrf)
    {
        return new IrrfModel
        {
            Id = irrf.Id,
            Competencia = irrf.Competencia,
            Faixa = irrf.Faixa,
            Porcentagem = irrf.Porcentagem,
            Valor = irrf.Valor,
            Deducao = irrf.Deducao
        };
    }
    public static IrrfDto ConverteIrrfParaDto(this IrrfModel irrf)
    {
        return new IrrfDto
        {
            Id = irrf.Id,
            Competencia = irrf.Competencia,
            Faixa = irrf.Faixa,
            Porcentagem = irrf.Porcentagem,
            Valor = irrf.Valor,
            Deducao = irrf.Deducao
        };
    }
}
