﻿using CalculoImposto.Application.Dtos.IrrfDescontoMinimo;
using CalculoImposto.Domain.Abstractions;
using CalculoImposto.Domain.Respositories.Irrf.Interface;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.Delete;

public sealed class Handler(IDescontoMinimoRespository _descontoMinimoRespository, IUnitOfWork _unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var descontoMinimo = await _descontoMinimoRespository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.CommitAsynk();
        return descontoMinimo is null ?
            Result.Failure<Response>(Error.NotFound("Desconto Minimo não encontrado")) :
            Result.Success(new Response(descontoMinimo.ToDescontoMinimoFromDescontoMinimoDto()));
    }
}
