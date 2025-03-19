using CalculoImposto.Domain.Abstractions;

namespace CalculoImposto.Domain.Entities;

public class Irrf : Entity
{
    public int Faixa { get; set; }
    public decimal Porcentagem { get; set; }
    public decimal Deducao { get; set; }
}
