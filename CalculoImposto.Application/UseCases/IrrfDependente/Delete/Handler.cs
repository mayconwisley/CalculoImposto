using CalculoImposto.Application.Dtos.IrrfDependente;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDependente.Delete;

public sealed class Handler(IDependenteRepository _dependenteRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var dependente = await _dependenteRepository.DeleteAsync(request.Id, cancellationToken);
        return dependente is null ?
            Result.Failure<Response>(Error.NotFound("Dependente não encontrado")) :
            Result.Success(new Response(dependente.ToDependenteFromDependenteDto()));
    }
}
