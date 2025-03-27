namespace CalculoImposto.Application.Dtos.Irrf;

public static class MappingDto
{
    public static IEnumerable<IrrfDto> ToListIrrfFromIrrfDto(this IEnumerable<Domain.Entities.Irrf> irrfList)
    {
        return [.. (from irrf in irrfList
            select new IrrfDto(irrf.Id, irrf.Range, irrf.Percent, irrf.Deduction, irrf.Competence, irrf.Value)
        )];
    }
    public static IEnumerable<Domain.Entities.Irrf> ToListIrrfDtoFromListIrrf(this IEnumerable<IrrfDto> irrfDtoList)
    {
        return [.. (from irrf in irrfDtoList
            select new Domain.Entities.Irrf()
            {
                Id = irrf.Id,
                Range = irrf.Range,
                Percent = irrf.Percent,
                Deduction = irrf.Deduction,
                Competence = irrf.Competence,
                Value = irrf.Value
            }
        )];
    }
    public static IrrfDto ToIrrfFromIrrfDto(this Domain.Entities.Irrf irrf)
    {
        return new IrrfDto(irrf.Id, irrf.Range, irrf.Percent, irrf.Deduction, irrf.Competence, irrf.Value);
    }
    public static Domain.Entities.Irrf ToIrrfDtoFromIrrf(this IrrfDto irrfDto)
    {
        return new Domain.Entities.Irrf()
        {
            Id = irrfDto.Id,
            Range = irrfDto.Range,
            Percent = irrfDto.Percent,
            Deduction = irrfDto.Deduction,
            Competence = irrfDto.Competence,
            Value = irrfDto.Value
        };
    }
    public static Domain.Entities.Irrf ToIrrfCreateDtoFromInss(this IrrfCreateDto irrfCreateDto)
    {
        return new Domain.Entities.Irrf()
        {
            Id = Guid.NewGuid(),
            Range = irrfCreateDto.Range,
            Percent = irrfCreateDto.Percent,
            Deduction = irrfCreateDto.Deduction,
            Competence = irrfCreateDto.Competence,
            Value = irrfCreateDto.Value
        };
    }
}
