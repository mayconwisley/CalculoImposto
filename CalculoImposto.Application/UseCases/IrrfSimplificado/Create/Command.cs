using CalculoImposto.Application.Dtos.IrrfSimplificado;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.Create;

public sealed record Command(SimplificadoCreateDto SimplificadoCreateDto) : IRequest<Result<Response>>;

