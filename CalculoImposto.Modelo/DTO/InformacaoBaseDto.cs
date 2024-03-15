using System.ComponentModel.DataAnnotations;

namespace CalculoImposto.Modelo.DTO;

public class InformacaoBaseDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Informar a competência")]
    public DateTime Competencia { get; set; }
    [Required(ErrorMessage = "Informar a valor")]
    public decimal Valor { get; set; }
}
