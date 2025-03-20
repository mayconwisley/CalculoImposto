using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.Update;

public sealed record Command(Domain.Entities.Inss Inss) : IRequest<Result<Response>>;
