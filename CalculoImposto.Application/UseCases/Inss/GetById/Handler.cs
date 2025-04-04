﻿using CalculoImposto.Application.Dtos.Inss;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Inss.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetById;

public sealed class Handler(IInssRepository _inssRepository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var inss = await _inssRepository.GetByIdAsync(request.Id, cancellationToken);
        return inss is null ?
            Result.Failure<Response>(Error.NotFound("Inss não encontrado")) :
            Result.Success(new Response(inss.ToInssFromInssDto()));
    }
}
