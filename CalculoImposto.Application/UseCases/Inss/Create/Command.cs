using CalculoImposto.Application.Dtos.Inss;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.Create;

public sealed record Command(InssCreateDto InssCreateDto) : IRequest<Result<Response>>;
