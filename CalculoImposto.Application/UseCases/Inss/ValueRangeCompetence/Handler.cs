using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.ValueRangeCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var valueRangeCompetence = await _inssRepository.GetRangeAsync(request.Competence, request.Range, cancellationToken);
        return valueRangeCompetence == 0 ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) : Result.Success(new Response(valueRangeCompetence));
    }
}
