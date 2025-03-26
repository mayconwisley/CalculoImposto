using CalculoImposto.Application.Dtos.Inss;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.Update;

public sealed record Command(InssDto InssDto) : IRequest<Result<Response>>;
