using CalculoImposto.Domain.Abstractions;

namespace CalculoImposto.Domain.Entities;

public class Irrf : Entity
{
    public int Range { get; set; }
    public decimal Percent { get; set; }
    public decimal Deduction { get; set; }
}
