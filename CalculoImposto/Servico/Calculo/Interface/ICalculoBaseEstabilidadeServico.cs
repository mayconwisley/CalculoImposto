namespace CalculoImposto.API.Servico.Calculo.Interface;

public interface ICalculoBaseEstabilidadeServico
{
    public Task<decimal> Indenizacao(decimal valorMedia, int diasBase, int diasEstabilidade);
    public Task<decimal> DecimoTerceiro(decimal valorMedia, int diasEstabilidade);
    public Task<decimal> Ferias(decimal valorMedia, int diasEstabilidade);
    public Task<decimal> TercoFerias(decimal valorFerias);
    public Task<decimal> FGTS8(decimal valorEstabilidade, decimal decimoTerceiro);
    public Task<decimal> FGTS40(decimal FGTS8);
}
