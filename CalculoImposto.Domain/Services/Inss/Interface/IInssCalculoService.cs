namespace CalculoImposto.Domain.Services.Inss.Interface;

public interface IInssCalculoService
{
    Task<decimal> CalculoNormal(DateTime competence, decimal baseInss);
}
