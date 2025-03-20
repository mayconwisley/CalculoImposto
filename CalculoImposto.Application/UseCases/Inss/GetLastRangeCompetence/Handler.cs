using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetLastRangeCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var lastRange = await _inssRepository.GetLastRangeCompetenceAsync(request.Competence, cancellationToken);
        return lastRange == 0 ? Result.Failure<Response>(Error.NotFound("Ultima faixa não encintrada na competência informada")) :
                                Result.Success(new Response(lastRange));
    }
}
