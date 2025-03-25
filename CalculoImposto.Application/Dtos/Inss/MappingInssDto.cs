namespace CalculoImposto.Application.Dtos.Inss;

public static class MappingInssDto
{
    public static IEnumerable<InssDto> ToListInssByDto(this IEnumerable<Domain.Entities.Inss> inssList)
    {
        return [.. (from inss in inssList
                select new InssDto(inss.Id, inss.Range, inss.Percent, inss.Competence, inss.Value)
            )];
    }

    public static IEnumerable<Domain.Entities.Inss> ToListDtoByInss(this IEnumerable<InssDto> inssDtoList)
    {
        return [.. (from inss in inssDtoList
                    select new Domain.Entities.Inss()
                    {
                        Id = inss.Id,
                        Range = inss.Range,
                        Percent = inss.Percent,
                        Competence = inss.Competence,
                        Value = inss.Value
                    }
            )];
    }

    public static InssDto ToInssDto(this Domain.Entities.Inss inss)
    {
        return new InssDto(inss.Id, inss.Range, inss.Percent, inss.Competence, inss.Value);
    }

    public static Domain.Entities.Inss ToInss(this InssDto inssDto)
    {
        return new Domain.Entities.Inss()
        {
            Id = inssDto.Id,
            Range = inssDto.Range,
            Percent = inssDto.Percent,
            Competence = inssDto.Competence,
            Value = inssDto.Value
        };
    }
}
