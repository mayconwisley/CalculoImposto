using CalculoImposto.Application.Dtos.IrrfDependente;
using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDependente.Update;

public sealed record Command(DependenteDto DependenteDto) : IRequest<Result<Response>>;
