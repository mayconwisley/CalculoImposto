namespace CalculoImposto.Application.Dtos.Inss;

public static class MappingInssDto
{
    public static IEnumerable<InssDto> ToListInssDto(this IEnumerable<Domain.Entities.Inss> inssList)
    {
        return [.. (from inss in inssList
                select new InssDto(inss.Id, inss.Range, inss.Percent, inss.Competence, inss.Value)
            )];
    }
}
