using CalculoImposto.Application.Dtos.IrrfDependente;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDependente.Update;

public sealed class Handler(IDependenteRepository _dependenteRepository, IUnitOfWork _unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var dependente = await _dependenteRepository.UpdateAsync(request.DependenteDto.ToDependenteDtoFromDependente(), cancellationToken);
        await _unitOfWork.CommitAsynk();
        return dependente is null ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) :
                              Result.Success(new Response(dependente.ToDependenteFromDependenteDto()));
    }
}
