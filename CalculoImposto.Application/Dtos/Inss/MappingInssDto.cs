namespace CalculoImposto.Application.Dtos.Inss;

public static class MappingInssDto
{
    public static IEnumerable<InssDto> ToListInssFromInssDto(this IEnumerable<Domain.Entities.Inss> inssList)
    {
        return [.. (from inss in inssList
                select new InssDto(inss.Id, inss.Range, inss.Percent, inss.Competence, inss.Value)
            )];
    }

    public static IEnumerable<Domain.Entities.Inss> ToListInssDtoFromListInss(this IEnumerable<InssDto> inssDtoList)
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

    public static InssDto ToInssFromInssDto(this Domain.Entities.Inss inss)
    {
        return new InssDto(inss.Id, inss.Range, inss.Percent, inss.Competence, inss.Value);
    }

    public static Domain.Entities.Inss ToInssCreateDtoFromInss(this InssCreateDto inssCreateDto)
    {
        return new Domain.Entities.Inss()
        {
            Id = Guid.NewGuid(),
            Range = inssCreateDto.Range,
            Percent = inssCreateDto.Percent,
            Competence = inssCreateDto.Competence,
            Value = inssCreateDto.Value
        };
    }

    public static Domain.Entities.Inss ToInssDtoFromInss(this InssDto inssDto)
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
