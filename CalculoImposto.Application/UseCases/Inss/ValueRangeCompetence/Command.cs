using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.ValueRangeCompetence;

public sealed record Command(DateTime Competence, int Range) : IRequest<Result<Response>>;
