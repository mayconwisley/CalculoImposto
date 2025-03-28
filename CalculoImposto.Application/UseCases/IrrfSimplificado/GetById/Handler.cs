using CalculoImposto.Application.Dtos.IrrfSimplificado;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.GetById;

public sealed class Handler(ISimplificadoRepository _simplificadoRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var simplificado = await _simplificadoRepository.GetByIdAsync(request.Id, cancellationToken);
        return simplificado is null ?
            Result.Failure<Response>(Error.NotFound("Simplificado não encontrado")) :
            Result.Success(new Response(simplificado.ToSimplificadoFromSimplificadoDto()));
    }
}
