﻿using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.Update;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var inss = await _inssRepository.UpdateAsync(request.Inss, cancellationToken);
        return inss is null ? Result.Failure<Response>(Error.BadRequest("Conteudo Nulo")) : Result.Success(new Response(inss));
    }
}
