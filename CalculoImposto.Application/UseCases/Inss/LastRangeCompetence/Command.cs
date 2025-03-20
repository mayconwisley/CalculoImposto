using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.LastRangeCompetence;

public sealed record Command(DateTime Competence) : IRequest<Result<Response>>;
