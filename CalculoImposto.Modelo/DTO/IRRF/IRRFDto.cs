using System.ComponentModel.DataAnnotations;

namespace CalculoImposto.Modelo.DTO.IRRF;

public class IrrfDto : InformacaoBaseDto
{
    [Required(ErrorMessage = "Informar a faixa")]
    public int Faixa { get; set; }
    [Required(ErrorMessage = "Informar a porcentagem")]
    public decimal Porcentagem { get; set; }
    [Required(ErrorMessage = "Informar a dedução")]
    public decimal Deducao { get; set; }
}
