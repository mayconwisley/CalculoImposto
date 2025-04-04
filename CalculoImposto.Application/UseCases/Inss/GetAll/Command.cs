﻿using CalculoImposto.Domain.Abstractions;
using MediatR;

namespace CalculoImposto.Application.UseCases.Inss.GetAll;

public sealed record Command(int Page = 1, int Size = 25) : IRequest<Result<Response>>;
