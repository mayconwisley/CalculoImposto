using CalculoImposto.Application.Dtos.Irrf;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Irrf.Create;

public sealed class Handler(IIrrfRepository _irrfRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var irrf = await _irrfRepository.CreateAsync(request.IrrfCreateDto.ToIrrfCreateDtoFromIrrf(), cancellationToken);
        return irrf is null ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) :
                              Result.Success(new Response(irrf.ToIrrfFromIrrfDto()));
    }
}
