using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.PercentRangeCompetence;

public sealed record Command(DateTime Competence, int Range) : IRequest<Result<Response>>;
