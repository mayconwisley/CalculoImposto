using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetPercentRangeCompetence;

public sealed record Command(DateTime Competence, int Range) : IRequest<Result<Response>>;
