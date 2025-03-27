using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.Inss;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetAll;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var totalItems = await _inssRepository.GetCountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((decimal)totalItems / request.Size);
        var inssList = await _inssRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var inssDto = new PagedResult<InssDto>
        (
            inssList.ToListInssFromInssDto(),
            totalItems,
            totalPages,
            request.Page
        );

        return inssDto is null ?
               Result.Failure<Response>(Error.NotFound("Lista de Inss não encontrado")) :
               Result.Success(new Response(inssDto));
    }
}
