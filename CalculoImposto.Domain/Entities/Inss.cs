using CalculoImposto.Domain.Abstractions;

namespace CalculoImposto.Domain.Entities;

public class Inss : Entity
{
    public int Faixa { get; set; }
    public decimal Porcentagem { get; set; }
}
