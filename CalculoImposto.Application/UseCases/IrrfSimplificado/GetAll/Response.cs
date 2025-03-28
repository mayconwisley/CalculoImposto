using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.IrrfSimplificado;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.GetAll;

public sealed record Response(PagedResult<SimplificadoDto> SimplificadoDtoResult);
