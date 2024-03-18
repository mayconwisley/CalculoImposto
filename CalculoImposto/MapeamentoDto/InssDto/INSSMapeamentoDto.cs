using CalculoImposto.API.Model.INSS;
using CalculoImposto.Modelo.DTO.INSS;

namespace CalculoImposto.API.MapeamentoDto.InssDto;

public static class INSSMapeamentoDto
{
    public static IEnumerable<INSSDto> ConverterInssParaDtos(this IEnumerable<INSSModel> inss)
    {
        return (from ins in inss
                select new INSSDto
                {
                    Id = ins.Id,
                    Competencia = ins.Competencia,
                    Faixa = ins.Faixa,
                    Porcentagem = ins.Porcentagem,
                    Valor = ins.Valor

                }).ToList();
    }
    public static IEnumerable<INSSModel> ConverterDtosParaInss(this IEnumerable<INSSDto> inss)
    {
        return (from ins in inss
                select new INSSModel
                {
                    Id = ins.Id,
                    Competencia = ins.Competencia,
                    Faixa = ins.Faixa,
                    Porcentagem = ins.Porcentagem,
                    Valor = ins.Valor

                }).ToList();
    }
    public static INSSModel ConverteDtoParaInss(this INSSDto inss)
    {
        return new INSSModel
        {
            Id = inss.Id,
            Competencia = inss.Competencia,
            Faixa = inss.Faixa,
            Porcentagem = inss.Porcentagem,
            Valor = inss.Valor
        };
    }
    public static INSSDto ConverteInssParaDto(this INSSModel inss)
    {
        return new INSSDto
        {
            Id = inss.Id,
            Competencia = inss.Competencia,
            Faixa = inss.Faixa,
            Porcentagem = inss.Porcentagem,
            Valor = inss.Valor
        };
    }
}
