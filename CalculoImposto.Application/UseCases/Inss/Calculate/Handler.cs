using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Services.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.Calculate;

public sealed class Handler(IInssCalculoService _inssCalculoService) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var value = await _inssCalculoService.CalculoNormal(request.Competence, request.BaseInss);

        return value <= 0 ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) :
                           Result.Success(new Response(value));
    }
}
