using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Irrf.GetById;

public sealed record Command(Guid Id) : IRequest<Result<Response>>;

