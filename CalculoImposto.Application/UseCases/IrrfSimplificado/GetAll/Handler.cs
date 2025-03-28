using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.IrrfSimplificado;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfSimplificado.GetAll;

public sealed class Handler(ISimplificadoRepository _simplificadoRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var totalItems = await _simplificadoRepository.GetCountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((decimal)totalItems / request.Size);
        var simplificadoList = await _simplificadoRepository.GetAllAsync(request.Page, request.Size, request.Search, cancellationToken);

        if (simplificadoList is null)
        {
            return Result.Failure<Response>(Error.NotFound("Lista de Simplificado não encontrado"));
        }

        var simplificadoDto = new PagedResult<SimplificadoDto>
        (
            simplificadoList!.ToListSimplificadoFromSimplificadoDto(),
            totalItems,
            totalPages,
            request.Page
        );

        return Result.Success(new Response(simplificadoDto));
    }
}
