using CalculoImposto.Application.Dtos.IrrfSimplificado;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.Update;

public sealed class Handler(ISimplificadoRepository _simplificadoRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var simplificado = await _simplificadoRepository.UpdateAsync(request.SimplificadoDto.ToSimplificadoDtoDependenteSimplificado(), cancellationToken);
        return simplificado is null ?
            Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) :
            Result.Success(new Response(simplificado.ToSimplificadoFromSimplificadoDto()));
    }
}
