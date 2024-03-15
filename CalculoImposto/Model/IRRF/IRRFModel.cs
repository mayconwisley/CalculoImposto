namespace CalculoImposto.API.Model.IRRF;

public class IRRFModel : InformacaoBaseModel
{
    public int Faixa { get; set; }
    public decimal Porcentagem { get; set; }
    public decimal Deducao { get; set; }
}
