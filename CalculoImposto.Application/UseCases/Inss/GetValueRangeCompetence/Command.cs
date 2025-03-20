using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetValueRangeCompetence;

public sealed record Command(DateTime Competence, int Range) : IRequest<Result<Response>>;
