namespace CalculoImposto.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime Competence { get; set; }
    public decimal Value { get; set; }
}
