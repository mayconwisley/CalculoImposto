using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.GetAll;

public sealed class Handler(IDescontoMinimoRespository _descontoMinimoRespository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var totalItems = await _descontoMinimoRespository.GetCountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((decimal)totalItems / request.Size);
        var descontoMinimoList = await _descontoMinimoRespository.GetAllAsync(request.Page, request.Size, request.Search, cancellationToken);

        if (descontoMinimoList is null)
        {
            return Result.Failure<Response>(Error.NotFound("Lista de Desconto Minimo não encontrado"));
        }

        var descontoMinimoDto = new PagedResult<DescontoMinimoDto>
        (
            descontoMinimoList!.ToListDescontoMinimoFromDescontoMinimoDto(),
            totalItems,
            totalPages,
            request.Page
        );

        return Result.Success(new Response(descontoMinimoDto));
    }
}
