using CalculoImposto.Domain.Abstractions;

namespace CalculoImposto.Domain.Entities;

public class Inss : Entity
{
    public int Range { get; set; }
    public decimal Percent { get; set; }
}
