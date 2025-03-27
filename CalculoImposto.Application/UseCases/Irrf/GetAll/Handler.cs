using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.Irrf;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Irrf.GetAll;

public sealed class Handler(IIrrfRepository _irrfRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var totalItems = await _irrfRepository.GetCountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((decimal)totalItems / request.Size);
        var irrfList = await _irrfRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var irrfDto = new PagedResult<IrrfDto>
        (
            irrfList.ToListIrrfFromIrrfDto(),
            totalItems,
            totalPages,
            request.Page
        );

        return irrfDto is null ?
               Result.Failure<Response>(Error.NotFound("Lista de Irrf não encontrado")) :
               Result.Success(new Response(irrfDto));
    }
}
