using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.TotalRange;

public sealed record Command(DateTime Competente) : IRequest<Result<Response>>;
