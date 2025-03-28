namespace CalculoImposto.Application.Dtos.IrrfDependente;

public static class MappingDto
{
    public static IEnumerable<DependenteDto> ToListDependenteFromDependenteDto(this IEnumerable<Domain.Entities.Dependente> dependenteList)
    {
        return [.. (from dependente in dependenteList
                    select new DependenteDto(dependente.Id, dependente.Competence, dependente.Value)
                )];
    }
    public static IEnumerable<Domain.Entities.Dependente> ToListDependenteDtoFromListIrrf(this IEnumerable<DependenteDto> dependenteDtoList)
    {
        return [.. (from dependente in dependenteDtoList
                    select new Domain.Entities.Dependente()
                    {
                        Id = dependente.Id,
                        Competence = dependente.Competence,
                        Value = dependente.Value
                    }
                )];
    }
    public static DependenteDto ToDependenteFromDependenteDto(this Domain.Entities.Dependente dependente)
    {
        return new DependenteDto(dependente.Id, dependente.Competence, dependente.Value);
    }
    public static Domain.Entities.Dependente ToDependenteDtoFromDependente(this DependenteDto dependenteDto)
    {
        return new Domain.Entities.Dependente()
        {
            Id = dependenteDto.Id,
            Competence = dependenteDto.Competence,
            Value = dependenteDto.Value
        };
    }
    public static Domain.Entities.Dependente ToDependenteCreateDtoFromDependente(this DependenteCreateDto dependenteCreateDto)
    {
        return new Domain.Entities.Dependente()
        {
            Id = Guid.NewGuid(),
            Competence = dependenteCreateDto.Competence,
            Value = dependenteCreateDto.Value
        };
    }
}
