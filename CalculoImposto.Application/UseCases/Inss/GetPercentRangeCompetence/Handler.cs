using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetPercentRangeCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var percentRange = await _inssRepository.GetPercentRangeCompetenceAsync(request.Competence, request.Range, cancellationToken);
        return percentRange == 0 ? Result.Failure<Response>(Error.NotFound("Percentual não encontrado na competência e faixa informado")) :
                                   Result.Success(new Response(percentRange));
    }
}
