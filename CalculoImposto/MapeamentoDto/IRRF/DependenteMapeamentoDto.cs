using CalculoImposto.API.Model.IRRF;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.MapeamentoDto.IRRF;

public static class DependenteMapeamentoDto
{
    public static IEnumerable<DependenteDto> ConverterDependentesParaDtos(this IEnumerable<DependenteModel> dependentes)
    {
        return (from dependente in dependentes
                select new DependenteDto
                {
                    Id = dependente.Id,
                    Competencia = dependente.Competencia,
                    Valor = dependente.Valor

                }).ToList();
    }
    public static IEnumerable<DependenteModel> ConverterDtosParaDependentes(this IEnumerable<DependenteDto> dependentes)
    {
        return (from dependente in dependentes
                select new DependenteModel
                {
                    Id = dependente.Id,
                    Competencia = dependente.Competencia,
                    Valor = dependente.Valor

                }).ToList();
    }

    public static DependenteDto ConverterDependenteParaDto(this DependenteModel dependente)
    {
        return new DependenteDto
        {
            Id = dependente.Id,
            Competencia = dependente.Competencia,
            Valor = dependente.Valor
        };
    }

    public static DependenteModel ConverterDtoParaDependente(this DependenteDto dependente)
    {
        return new DependenteModel
        {
            Id = dependente.Id,
            Competencia = dependente.Competencia,
            Valor = dependente.Valor
        };
    }
}
