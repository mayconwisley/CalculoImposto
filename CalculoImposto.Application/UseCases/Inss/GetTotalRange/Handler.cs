using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetTotalRange;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var totalRange = await _inssRepository.GetTotalRangeAsync(request.Competente, cancellationToken);
        return totalRange == 0 ? Result.Failure<Response>(Error.NotFound("Faixa não encontrada")) : Result.Success(new Response(totalRange));
    }
}
