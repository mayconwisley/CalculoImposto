using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.Calculate;

public sealed record Command(DateTime Competence, decimal BaseInss) : IRequest<Result<Response>>;