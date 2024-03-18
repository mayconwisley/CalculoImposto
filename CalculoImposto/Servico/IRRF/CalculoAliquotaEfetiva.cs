namespace CalculoImposto.API.Servico.IRRF;

public class CalculoAliquotaEfetiva
{
    public static decimal Calculo(decimal desconto, decimal valorBruto)
    {
        decimal aliquitaEfetiva;
        try
        {
            aliquitaEfetiva = (desconto / valorBruto) * 100;
            aliquitaEfetiva = Math.Truncate(aliquitaEfetiva * 100) / 100;
        }
        catch (Exception)
        {
            aliquitaEfetiva = 0m;
        }

        return aliquitaEfetiva;
    }
}
