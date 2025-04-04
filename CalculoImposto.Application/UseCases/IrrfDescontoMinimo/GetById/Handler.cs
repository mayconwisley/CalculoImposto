﻿using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.GetById;

public sealed class Handler(IDescontoMinimoRespository _descontoMinimoRespository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var descontoMinimo = await _descontoMinimoRespository.GetByIdAsync(request.Id, cancellationToken);
        return descontoMinimo is null ?
            Result.Failure<Response>(Error.NotFound("Desconto Minimo não encontrado")) :
            Result.Success(new Response(descontoMinimo.ToDescontoMinimoFromDescontoMinimoDto()));
    }
}
