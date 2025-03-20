using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetValueRangeCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var valueRangeCompetence = await _inssRepository.GetValueRangeCompetenceAsync(request.Competence, request.Range, cancellationToken);
        return valueRangeCompetence == 0 ? Result.Failure<Response>(Error.NotFound("Valor da faixa não encontrado na competência informada")) :
                                           Result.Success(new Response(valueRangeCompetence));
    }
}
