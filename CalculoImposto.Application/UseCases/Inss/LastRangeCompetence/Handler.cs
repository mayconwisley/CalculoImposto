using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.LastRangeCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var lastRange = await _inssRepository.LastRangeCompetenceAsync(request.Competence, cancellationToken);
        return lastRange == 0 ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) : Result.Success(new Response(lastRange));
    }
}
