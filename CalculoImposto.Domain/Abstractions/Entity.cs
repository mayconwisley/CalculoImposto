namespace CalculoImposto.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime Competencia { get; set; }
    public decimal Valor { get; set; }
}
