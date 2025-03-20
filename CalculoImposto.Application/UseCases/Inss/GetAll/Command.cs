using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetAll;

public sealed record Command(int Page = 0, int Size = 25) : IRequest<Result<Response>>;
