using CalculoImposto.API.Model.IRRF;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.MapeamentoDto.IRRF;

public static class DescontoMinimoMapeamentoDto
{
    public static IEnumerable<DescontoMinimoDto> ConverterDescontosMinimosParaDtos(this IEnumerable<DescontoMinimoModel> descontosMinimos)
    {
        return (from descontoMinimo in descontosMinimos
                select new DescontoMinimoDto
                {
                    Id = descontoMinimo.Id,
                    Competencia = descontoMinimo.Competencia,
                    Valor = descontoMinimo.Valor

                }).ToList();
    }
    public static IEnumerable<DescontoMinimoModel> ConverterDtosParaDescontosMinimos(this IEnumerable<DescontoMinimoDto> descontosMinimos)
    {
        return (from descontoMinimo in descontosMinimos
                select new DescontoMinimoModel
                {
                    Id = descontoMinimo.Id,
                    Competencia = descontoMinimo.Competencia,
                    Valor = descontoMinimo.Valor

                }).ToList();
    }

    public static DescontoMinimoDto ConverterDescontoMinimoParaDto(this DescontoMinimoModel descontoMinimo)
    {
        return new DescontoMinimoDto
        {
            Id = descontoMinimo.Id,
            Competencia = descontoMinimo.Competencia,
            Valor = descontoMinimo.Valor
        };
    }

    public static DescontoMinimoModel ConverterDtoParaDescontoMinimo(this DescontoMinimoDto descontoMinimo)
    {
        return new DescontoMinimoModel
        {
            Id = descontoMinimo.Id,
            Competencia = descontoMinimo.Competencia,
            Valor = descontoMinimo.Valor
        };
    }
}
