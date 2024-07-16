using CalculoImposto.API.Servico.Calculo.Interface;

namespace CalculoImposto.API.Servico.Calculo;

public class CalculoBaseEstabilidadeServico : ICalculoBaseEstabilidadeServico
{
    //Calculo valor da indenização sem as verbas adicionais
    public Task<decimal> Indenizacao(decimal media, int diasBase, int diasEstabilidade)
    {
        decimal vlrIndenizacao = (media / diasBase) * diasEstabilidade;
        vlrIndenizacao = Math.Round(vlrIndenizacao, 2);
        return Task.FromResult(vlrIndenizacao);
    }
    //Calculo 13º Salario
    public Task<decimal> DecimoTerceiro(decimal media, int diasEstabilidade)
    {
        decimal meses = diasEstabilidade / 30;
        decimal dias = diasEstabilidade - (Math.Floor(meses) * 30);

        if (dias >= 15)
        {
            return _ = Task.FromResult(Math.Round((media / 12) * (meses + 1), 2));
        }
        else
        {
            return _ = Task.FromResult(Math.Round((media / 12) * meses, 2));
        }
    }
    //Calculo Ferias
    public Task<decimal> Ferias(decimal media, int diasEstabilidade)
    {
        decimal meses = diasEstabilidade / 30;
        decimal dias = diasEstabilidade - (Math.Floor(meses) * 30);

        if (dias >= 15)
        {
            return _ = Task.FromResult(Math.Round((media / 12) * (meses + 1), 2));
        }
        else
        {
            return _ = Task.FromResult(Math.Round((media / 12) * meses, 2));
        }
    }
    //Calculo de 1 terço sobre a ferias
    public Task<decimal> TercoFerias(decimal valorFerias)
    {
        return _ = Task.FromResult(Math.Round(valorFerias / 3, 2));
    }
    //Calculo de 8% FGTS
    public Task<decimal> FGTS8(decimal valorEstabilidade, decimal decimoTerceiro)
    {
        return _ = Task.FromResult(Math.Round((valorEstabilidade + decimoTerceiro) * 0.08M, 2));
    }
    //Calculo de 40% FGTS
    public Task<decimal> FGTS40(decimal FGTS8)
    {
        return _ = Task.FromResult(Math.Round(FGTS8 * 0.40M, 2));
    }
}
