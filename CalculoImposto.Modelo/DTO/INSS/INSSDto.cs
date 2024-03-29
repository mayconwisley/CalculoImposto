﻿using System.ComponentModel.DataAnnotations;

namespace CalculoImposto.Modelo.DTO.INSS;

public class InssDto : InformacaoBaseDto
{
    [Required(ErrorMessage = "Informar a faixa")]
    public int Faixa { get; set; }
    [Required(ErrorMessage = "Informar a porcentagem")]
    public decimal Porcentagem { get; set; }
}
