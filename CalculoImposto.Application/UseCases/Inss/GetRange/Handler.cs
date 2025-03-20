using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetRange;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var range = await _inssRepository.GetRangeAsync(request.Competence, request.BaseInss, cancellationToken);
        return range == 0 ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) : Result.Success(new Response(range));
    }
}
