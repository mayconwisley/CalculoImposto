using CalculoImposto.Application.Dtos.IrrfSimplificado;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.GetByCompetence;

public sealed class Handler(ISimplificadoRepository _simplificadoRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var simplificadoList = await _simplificadoRepository.GetByCompetenceAsync(request.Competence, cancellationToken);
        return simplificadoList is null ?
            Result.Failure<Response>(Error.NotFound("Lista de Simplificado não encontrado")) :
            Result.Success(new Response(simplificadoList!.ToListSimplificadoFromSimplificadoDto()));
    }
}
