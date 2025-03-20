using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetValueRoofCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var valueRoofCompetence = await _inssRepository.GetValueRoofCompetenceAsync(request.Competence, cancellationToken);
        return valueRoofCompetence == 0 ? Result.Failure<Response>(Error.NotFound("Valor do teto não encontrado na competência informada")) :
                                          Result.Success(new Response(valueRoofCompetence));
    }
}
