using CalculoImposto.Application.Dtos;
using CalculoImposto.Application.Dtos.IrrfDependente;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDependente.GetAll;

public sealed class Handler(IDependenteRepository _dependenteRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var totalItems = await _dependenteRepository.GetTotalAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((decimal)totalItems / request.Size);
        var dependenteList = await _dependenteRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        if (dependenteList is null)
        {
            return Result.Failure<Response>(Error.NotFound("Lista de Irrf não encontrado"));
        }

        var dependenteDto = new PagedResult<DependenteDto>
        (
            dependenteList!.ToListDependenteFromDependenteDto(),
            totalItems,
            totalPages,
            request.Page
        );

        return Result.Success(new Response(dependenteDto));
    }
}
