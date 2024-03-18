using CalculoImposto.API.Model.IRRF;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.MapeamentoDto.IrrfDto;

public static class SimplificadoMapeamentoDto
{
    public static IEnumerable<SimplificadoDto> ConverterSimplificadosParaDtos(this IEnumerable<SimplificadoModel> simplificados)
    {
        return (from simplificado in simplificados
                select new SimplificadoDto
                {
                    Id = simplificado.Id,
                    Competencia = simplificado.Competencia,
                    Valor = simplificado.Valor

                }).ToList();
    }
    public static IEnumerable<SimplificadoModel> ConverterDtosParaSimplificados(this IEnumerable<SimplificadoDto> simplificados)
    {
        return (from simplificado in simplificados
                select new SimplificadoModel
                {
                    Id = simplificado.Id,
                    Competencia = simplificado.Competencia,
                    Valor = simplificado.Valor

                }).ToList();
    }

    public static SimplificadoDto ConverterSimplificadoParaDto(this SimplificadoModel simplificado)
    {
        return new SimplificadoDto
        {
            Id = simplificado.Id,
            Competencia = simplificado.Competencia,
            Valor = simplificado.Valor
        };
    }

    public static SimplificadoModel ConverterDtoParaSimplificado(this SimplificadoDto simplificado)
    {
        return new SimplificadoModel
        {
            Id = simplificado.Id,
            Competencia = simplificado.Competencia,
            Valor = simplificado.Valor
        };
    }
}
