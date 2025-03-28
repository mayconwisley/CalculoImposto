using CalculoImposto.Application.Dtos.IrrfDependente;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDependente.GetByCompetence;

public sealed class Handler(IDependenteRepository _dependenteRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var dependenteList = await _dependenteRepository.GetByCompetenceAsync(request.Competence, cancellationToken);
        return dependenteList is null ?
            Result.Failure<Response>(Error.NotFound("Lista de Irrf não encontrado")) :
            Result.Success(new Response(dependenteList!.ToListDependenteFromDependenteDto()));
    }
}
