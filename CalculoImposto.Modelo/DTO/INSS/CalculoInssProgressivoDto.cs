namespace CalculoImposto.Modelo.DTO.INSS;

public class CalculoInssProgressivoDto
{
    public decimal BaseCalculo { get; set; }
    public decimal TotalDesconto { get; set; }
    public List<CalculoInssProgressivoFaixaDto>? Faixas { get; set; }
}
