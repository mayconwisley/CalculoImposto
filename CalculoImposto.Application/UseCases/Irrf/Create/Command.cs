using CalculoImposto.Application.Dtos.Irrf;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Irrf.Create;

public sealed record Command(IrrfCreateDto IrrfCreateDto) : IRequest<Result<Response>>;

