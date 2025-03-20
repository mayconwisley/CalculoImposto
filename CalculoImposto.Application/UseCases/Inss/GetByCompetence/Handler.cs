using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetByCompetence;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var inssList = await _inssRepository.GetByCompetenceAsync(request.Competence, cancellationToken);
        return inssList is null ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) : Result.Success(new Response(inssList));
    }
}
