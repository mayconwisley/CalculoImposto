namespace CalculoImposto.Modelo.DTO.IRRF;

public class CalculoSimplificadoDto
{
    public decimal ValorBruto { get; set; }
    public decimal ValorSimplificado { get; set; }
    public decimal ValorBaseIr { get; set; }
    public decimal PorcentagemIrrf { get; set; }
    public decimal DeduçãoIrrf { get; set; }
    public decimal Desconto { get; set; }
    public decimal Aliquota { get; set; }

}
