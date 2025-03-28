using CalculoImposto.Application.Dtos.IrrfSimplificado;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.Update;

public sealed record Command(SimplificadoDto SimplificadoDto) : IRequest<Result<Response>>;
