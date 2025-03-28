using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.GetByCompetence;

public sealed record Command(DateTime Competence) : IRequest<Result<Response>>;