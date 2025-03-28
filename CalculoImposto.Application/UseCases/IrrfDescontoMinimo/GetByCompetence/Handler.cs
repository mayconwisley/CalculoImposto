using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.GetByCompetence;

public sealed class Handler(IDescontoMinimoRespository _descontoMinimoRespository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var descontoMinimoList = await _descontoMinimoRespository.GetByCompetenceAsync(request.Competence, cancellationToken);
        return descontoMinimoList is null ?
            Result.Failure<Response>(Error.NotFound("Lista de Desconto Minimo não encontrado")) :
            Result.Success(new Response(descontoMinimoList!.ToListDescontoMinimoFromDescontoMinimoDto()));
    }
}
