using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.Update;

public sealed record Command(DescontoMinimoDto DescontoMinimoDto) : IRequest<Result<Response>>;
