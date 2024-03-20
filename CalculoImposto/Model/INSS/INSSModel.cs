namespace CalculoImposto.API.Model.INSS;

public class InssModel : InformacaoBaseModel
{
    public int Faixa { get; set; }
    public decimal Porcentagem { get; set; }
}
