namespace CalculoImposto.API.Model;

public class InformacaoBaseModel
{
    public int Id { get; set; }
    public DateTime Competencia { get; set; }
    public decimal Valor { get; set; }
}
