using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.Create;

public sealed record Command(DescontoMinimoCreateDto DescontoMinimoCreateDto) : IRequest<Result<Response>>;

