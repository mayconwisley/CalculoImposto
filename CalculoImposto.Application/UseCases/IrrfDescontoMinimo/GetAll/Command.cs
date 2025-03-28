using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.IrrfDescontoMinimo.GetAll;

public sealed record Command(int Page = 1, int Size = 25, string Search = "") : IRequest<Result<Response>>;
