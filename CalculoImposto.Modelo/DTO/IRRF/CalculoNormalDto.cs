namespace CalculoImposto.Modelo.DTO.IRRF;

public class CalculoNormalDto : CalculoBaseDto
{
    public decimal Porcentagem { get; set; }
    public decimal Deducao { get; set; }
    public decimal Desconto { get; set; }
    public decimal AliquotaEfetiva { get; set; }
}
