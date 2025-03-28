namespace CalculoImposto.Application.Dtos.IrrfDescontoMinimo;

public static class MappingDto
{
    public static IEnumerable<DescontoMinimoDto> ToListDescontoMinimoFromDescontoMinimoDto(this IEnumerable<Domain.Entities.DescontoMinimo> descontoMinimoList)
    {
        return [.. (from descontoMinimo in descontoMinimoList
                    select new DescontoMinimoDto(descontoMinimo.Id, descontoMinimo.Competence, descontoMinimo.Value)
        )];
    }
    public static IEnumerable<Domain.Entities.DescontoMinimo> ToListDescontoMinimoDtoFromDescontoMinimo(this IEnumerable<DescontoMinimoDto> descontoMinimoDtoList)
    {
        return [.. (from descontoMinimo in descontoMinimoDtoList
                    select new Domain.Entities.DescontoMinimo()
                    {
                        Id = descontoMinimo.Id,
                        Competence = descontoMinimo.Competence,
                        Value = descontoMinimo.Value
                    }
                )];
    }
    public static DescontoMinimoDto ToDescontoMinimoFromDescontoMinimoDto(this Domain.Entities.DescontoMinimo descontoMinimo)
    {
        return new DescontoMinimoDto(descontoMinimo.Id, descontoMinimo.Competence, descontoMinimo.Value);
    }
    public static Domain.Entities.DescontoMinimo ToDescontoMinimoDtoDependenteDescontoMinimo(this DescontoMinimoDto descontoMinimoDto)
    {
        return new Domain.Entities.DescontoMinimo()
        {
            Id = descontoMinimoDto.Id,
            Competence = descontoMinimoDto.Competence,
            Value = descontoMinimoDto.Value
        };
    }
    public static Domain.Entities.DescontoMinimo ToDescontoMinimoCreateDtoFromDescontoMinimo(this DescontoMinimoCreateDto descontoMinimoCreateDto)
    {
        return new Domain.Entities.DescontoMinimo()
        {
            Id = Guid.NewGuid(),
            Competence = descontoMinimoCreateDto.Competence,
            Value = descontoMinimoCreateDto.Value
        };
    }
}
