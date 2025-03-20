using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.PercentRangeCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var percentRange = await _inssRepository.PercentRangeCompetenceAsync(request.Competence, request.Range, cancellationToken);
        return percentRange == 0 ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) : Result.Success(new Response(percentRange));
    }
}
