using CalculoImposto.Application.Dtos.Irrf;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Irrf.Create;

public sealed class Handler(IIrrfRepository _irrfRepository, IUnitOfWork _unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var irrf = await _irrfRepository.CreateAsync(request.IrrfCreateDto.ToIrrfCreateDtoFromIrrf(), cancellationToken);
        await _unitOfWork.CommitAsynk();
        return irrf is null ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) :
                              Result.Success(new Response(irrf.ToIrrfFromIrrfDto()));
    }
}
