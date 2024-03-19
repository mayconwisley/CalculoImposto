namespace CalculoImposto.Modelo.DTO.IRRF;

public class CalculoBaseDto
{
    public decimal ValorBruto { get; set; }
    public decimal ValorInss { get; set; }
    public int QtdDependente { get; set; }
    public decimal ValorDependente { get; set; }
    public decimal ValorTotalDependente { get; set; }
    public decimal ValorBaseIr { get; set; }
}
