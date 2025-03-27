using CalculoImposto.Application.Dtos.Irrf;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Irrf.GetByCompetence;

public sealed class Handler(IIrrfRepository _irrfRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var irrfList = await _irrfRepository.GetByCompetenceAsync(request.Competence, cancellationToken);
        return irrfList is null ?
            Result.Failure<Response>(Error.NotFound("Lista de Irrf não encontrado")) :
            Result.Success(new Response(irrfList.ToListIrrfFromIrrfDto()));
    }
}
