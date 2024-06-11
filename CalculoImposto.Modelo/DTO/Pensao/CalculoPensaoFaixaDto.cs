namespace CalculoImposto.Modelo.DTO.Pensao;

public class CalculoPensaoFaixaDto
{
    public string? Faixa { get; set; }
    public decimal Porcentagem { get; set; }
    public decimal BaseIr { get; set; }
    public decimal ValorIr { get; set; }
    public decimal BasePensao { get; set; }
    public decimal ValorPensao { get; set; }
}
