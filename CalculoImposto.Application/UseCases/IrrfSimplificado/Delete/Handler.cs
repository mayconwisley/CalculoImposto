using CalculoImposto.Application.Dtos.IrrfSimplificado;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.Delete;

public sealed class Handler(ISimplificadoRepository _simplificadoRepository, IUnitOfWork _unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var simplificado = await _simplificadoRepository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.CommitAsynk();
        return simplificado is null ?
            Result.Failure<Response>(Error.NotFound("Simplificado não encontrado")) :
            Result.Success(new Response(simplificado.ToSimplificadoFromSimplificadoDto()));
    }
}
