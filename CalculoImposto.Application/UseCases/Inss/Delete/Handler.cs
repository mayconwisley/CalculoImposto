using CalculoImposto.Application.Dtos.Inss;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.Delete;

public sealed class Handler(IInssRepository _inssRepository, IUnitOfWork _unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var inss = await _inssRepository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.CommitAsynk();
        return inss is null ? Result.Failure<Response>(Error.NotFound("Inss não encontrado")) :
                              Result.Success(new Response(inss.ToInssFromInssDto()));
    }
}
