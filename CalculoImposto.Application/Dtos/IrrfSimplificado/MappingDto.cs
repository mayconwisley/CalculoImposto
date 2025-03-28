namespace CalculoImposto.Application.Dtos.IrrfSimplificado;

public static class MappingDto
{
    public static IEnumerable<SimplificadoDto> ToListSimplificadoFromSimplificadoDto(this IEnumerable<Domain.Entities.Simplificado> simplificadoList)
    {
        return [.. (from simplificado in simplificadoList
                    select new SimplificadoDto(simplificado.Id, simplificado.Competence, simplificado.Value)
        )];
    }
    public static IEnumerable<Domain.Entities.Simplificado> ToListSimplificadoDtoFromSimplificado(this IEnumerable<SimplificadoDto> simplificadoDtoList)
    {
        return [.. (from simplificado in simplificadoDtoList
                    select new Domain.Entities.Simplificado()
                    {
                        Id = simplificado.Id,
                        Competence = simplificado.Competence,
                        Value = simplificado.Value
                    }
                )];
    }
    public static SimplificadoDto ToSimplificadoFromSimplificadoDto(this Domain.Entities.Simplificado simplificado)
    {
        return new SimplificadoDto(simplificado.Id, simplificado.Competence, simplificado.Value);
    }
    public static Domain.Entities.Simplificado ToSimplificadoDtoDependenteSimplificado(this SimplificadoDto simplificadoDto)
    {
        return new Domain.Entities.Simplificado()
        {
            Id = simplificadoDto.Id,
            Competence = simplificadoDto.Competence,
            Value = simplificadoDto.Value
        };
    }
    public static Domain.Entities.Simplificado ToSimplificadoCreateDtoFromSimplificado(this SimplificadoCreateDto simplificadoCreateDto)
    {
        return new Domain.Entities.Simplificado()
        {
            Id = Guid.NewGuid(),
            Competence = simplificadoCreateDto.Competence,
            Value = simplificadoCreateDto.Value
        };
    }
}
