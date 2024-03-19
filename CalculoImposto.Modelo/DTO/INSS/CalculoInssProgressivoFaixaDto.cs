namespace CalculoImposto.Modelo.DTO.INSS;

public class CalculoInssProgressivoFaixaDto
{
    public string? Faixa { get; set; }
    public decimal Base { get; set; }
    public decimal Porcentagem { get; set; }
    public decimal Imposto { get; set; }
}
