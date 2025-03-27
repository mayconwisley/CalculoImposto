using CalculoImposto.Application.Dtos.Irrf;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Irrf.Update;

public sealed record Command(IrrfDto IrrfDto) : IRequest<Result<Response>>;
