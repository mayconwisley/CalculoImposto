namespace CalculoImposto.Modelo.DTO.IRRF;

public class CalculoProgressivoFaixaDto
{
    public string? Faixa { get; set; }
    public decimal ValorBaseIr { get; set; }
    public decimal Porcentagem { get; set; }
    public decimal ValorDesconto { get; set; }
    public decimal AliquotaEfetiva { get; set; }
}
