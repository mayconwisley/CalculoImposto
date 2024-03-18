namespace CalculoImposto.API.Model.INSS;

public class INSSModel : InformacaoBaseModel
{
    public int Faixa { get; set; }
    public decimal Porcentagem { get; set; }
}
