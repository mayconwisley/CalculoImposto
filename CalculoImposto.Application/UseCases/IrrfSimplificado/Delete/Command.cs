using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.Delete;

public sealed record Command(Guid Id) : IRequest<Result<Response>>;
