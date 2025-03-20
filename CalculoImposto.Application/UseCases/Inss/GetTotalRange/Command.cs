using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetTotalRange;

public sealed record Command(DateTime Competente) : IRequest<Result<Response>>;
