using CalculoImposto.Application.Dtos.IrrfDependente;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDependente.Create;

public sealed record Command(DependenteCreateDto DependenteCreateDto) : IRequest<Result<Response>>;

