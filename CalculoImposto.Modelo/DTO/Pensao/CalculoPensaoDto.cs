namespace CalculoImposto.Modelo.DTO.Pensao;

public class CalculoPensaoDto
{
    public decimal TotalDesconto { get; set; }
    public decimal PorcentagemPensao { get; set; }
    public List<CalculoPensaoFaixaDto>? Faixas { get; set; }
}
