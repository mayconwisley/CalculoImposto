using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDependente.GetByCompetence;

public sealed record Command(DateTime Competence) : IRequest<Result<Response>>;