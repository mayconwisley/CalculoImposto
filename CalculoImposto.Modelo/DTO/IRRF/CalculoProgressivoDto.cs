namespace CalculoImposto.Modelo.DTO.IRRF;

public class CalculoProgressivoDto : CalculoBaseDto
{
    public decimal TotalDesconto { get; set; }
    public List<CalculoProgressivoFaixaDto>? Faixas { get; set; }
}
