﻿using System.Diagnostics.CodeAnalysis;

namespace CalculoImposto.Domain.Abstractions;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        IsSucess = isSuccess switch
        {
            true when error != Error.None => throw new InvalidOperationException(),
            false when error == Error.None => throw new InvalidOperationException(),
            _ => isSuccess,
        };
    }

    public bool IsSucess { get; }
    public bool IsFailure => !IsSucess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Success<T>(T value) => new(value, true, Error.None);
    public static Result<T> Failure<T>(Error error) => new(default, false, error);

    public static Result<T> Create<T>(T? value) => value is not null ? Success(value) : Failure<T>(Error.NullValue);

}

public class Result<T> : Result
{
    private readonly T? _value;

    protected internal Result(T? value, bool isSuccess, Error error) : base(isSuccess, error) => _value = value;

    [NotNull]
    public T Value => _value! ?? throw new InvalidOperationException("Result has no value");

    public static implicit operator Result<T>(T? value) => Create(value);
}