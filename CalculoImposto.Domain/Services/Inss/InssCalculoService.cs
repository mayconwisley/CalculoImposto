using CalculoImposto.Domain.Respositories.Inss.Interface;
using CalculoImposto.Domain.Services.Inss.Interface;

namespace CalculoImposto.Domain.Services.Inss;

public class InssCalculoService(IInssRepository _inssRepository) : IInssCalculoService
{
    public async Task<decimal> CalculoNormal(DateTime competence, decimal baseInss)
    {
        decimal discount = 0m, previousValue = 0m;


        decimal tetoInss = await _inssRepository.GetValueRoofCompetenceAsync(competence);
        if (baseInss > tetoInss)
            baseInss = tetoInss;

        int range = await _inssRepository.GetRangeByCompetenceAndBaseInssAsync(competence, baseInss);

        for (int i = 1; i <= range; i++)
        {
            decimal percent = await _inssRepository.GetPercentRangeCompetenceAsync(competence, i);
            decimal value = await _inssRepository.GetValueRangeCompetenceAsync(competence, i);
            decimal baseCalcInss = value - previousValue;

            if (value > baseInss)
                baseCalcInss = baseInss - previousValue;

            if (baseCalcInss > baseInss)
                baseCalcInss = baseInss - previousValue;

            discount += baseCalcInss * (percent / 100);
            previousValue = value;
        }
        discount = Math.Round(discount, 2);
        return discount;
    }
}
