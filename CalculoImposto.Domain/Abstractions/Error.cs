namespace CalculoImposto.Domain.Abstractions;

public record Error(string Code, string Message)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "Um valor nulo foi fornecido.");
    public static Error NotFound(string message) => new("NotFound", message);
    public static Error BadRequest(string message) => new("BadRequest", message);
    public static Error InternalServerError(string message) => new("InternalServerError", message);
    public static Error Unauthorized(string message) => new("Unauthorized", message);
    public static Error Forbidden(string message) => new("Forbidden", message);
    public static Error Conflict(string message) => new("Conflict", message);
    public static Error ValidationError(string message) => new("ValidationError", message);
    public static Error NotImplemented(string message) => new("NotImplemented", message);
    public static Error ServiceUnavailable(string message) => new("ServiceUnavailable", message);
}
