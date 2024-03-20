using CalculoImposto.API.Model.INSS;
using CalculoImposto.Modelo.DTO.INSS;

namespace CalculoImposto.API.MapeamentoDto.InssDt;

public static class InssMapeamentoDto
{
    public static IEnumerable<InssDto> ConverterInssParaDtos(this IEnumerable<InssModel> inss)
    {
        return (from ins in inss
                select new InssDto
                {
                    Id = ins.Id,
                    Competencia = ins.Competencia,
                    Faixa = ins.Faixa,
                    Porcentagem = ins.Porcentagem,
                    Valor = ins.Valor

                }).ToList();
    }
    public static IEnumerable<InssModel> ConverterDtosParaInss(this IEnumerable<InssDto> inss)
    {
        return (from ins in inss
                select new InssModel
                {
                    Id = ins.Id,
                    Competencia = ins.Competencia,
                    Faixa = ins.Faixa,
                    Porcentagem = ins.Porcentagem,
                    Valor = ins.Valor

                }).ToList();
    }
    public static InssModel ConverteDtoParaInss(this InssDto inss)
    {
        return new InssModel
        {
            Id = inss.Id,
            Competencia = inss.Competencia,
            Faixa = inss.Faixa,
            Porcentagem = inss.Porcentagem,
            Valor = inss.Valor
        };
    }
    public static InssDto ConverteInssParaDto(this InssModel inss)
    {
        return new InssDto
        {
            Id = inss.Id,
            Competencia = inss.Competencia,
            Faixa = inss.Faixa,
            Porcentagem = inss.Porcentagem,
            Valor = inss.Valor
        };
    }
}
