using CalculoImposto.Domain.Respositories.Inss.Interface;
using CalculoImposto.Domain.Services.Inss.Interface;

namespace CalculoImposto.Domain.Services.Inss;

public class InssCalculoService(DateTime _competence, decimal _baseInss, IInssRepository _inssRepository) : IInssCalculoService
{
    public async Task<decimal> CalculoNormal()
    {
        decimal discount = 0m, previousValue = 0m;


        decimal tetoInss = await _inssRepository.GetValueRoofCompetenceAsync(_competence);
        if (_baseInss > tetoInss)
            _baseInss = tetoInss;

        int range = await _inssRepository.GetRangeByCompetenceAndBaseInssAsync(_competence, _baseInss);

        for (int i = 1; i <= range; i++)
        {
            decimal percent = await _inssRepository.GetPercentRangeCompetenceAsync(_competence, i);
            decimal value = await _inssRepository.GetValueRangeCompetenceAsync(_competence, i);
            decimal baseCalcInss = value - previousValue;

            if (value > _baseInss)
                baseCalcInss = _baseInss - previousValue;

            if (baseCalcInss > _baseInss)
                baseCalcInss = _baseInss - previousValue;

            discount += baseCalcInss * (percent / 100);
            previousValue = value;
        }
        discount = Math.Round(discount, 2);
        return discount;
    }
}
