using CalculoImposto.API.Banco;
using CalculoImposto.API.Model.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.IRRF;

public class IRRFRepositorio(CalculoImpostoContext calculoImpostoContext) : IIRRFRepositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext = calculoImpostoContext;

    public async Task<IRRFModel> AtualizarIrrf(IRRFModel irrf)
    {
        try
        {
            if (irrf is not null)
            {
                _calculoImpostoContext.IRRF.Entry(irrf).State = EntityState.Modified;
                await _calculoImpostoContext.SaveChangesAsync();
                return irrf;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<IRRFModel> CriarIrrf(IRRFModel irrf)
    {
        try
        {
            if (irrf is not null)
            {
                _calculoImpostoContext.IRRF.Add(irrf);
                await _calculoImpostoContext.SaveChangesAsync();
                return irrf;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<decimal> DeducaoFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        var deducao = await _calculoImpostoContext.IRRF
            .Where(w => w.Faixa == faixa &&
                        w.Competencia == _calculoImpostoContext.IRRF
                                         .Where(w => w.Competencia <= competencia)
                                         .Max(m => m.Competencia))
            .MaxAsync(m => m.Deducao);

        return deducao;

    }
    public async Task<IRRFModel> DeletarIrrf(int id)
    {
        try
        {
            var irrf = await PegarPorIdIrrf(id);
            if (irrf is not null)
            {
                _calculoImpostoContext.IRRF.Remove(irrf);
                await _calculoImpostoContext.SaveChangesAsync();
                return irrf;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<int> PegarFaixaIrrf(DateTime competencia, decimal baseIrrf)
    {
        var faixa = await _calculoImpostoContext.IRRF
            .Where(w => w.Valor >= baseIrrf &&
                        w.Competencia == _calculoImpostoContext.IRRF
                                         .Where(w => w.Competencia <= competencia)
                                         .Max(m => m.Competencia))
            .MinAsync(m => m.Faixa);

        return faixa;
    }
    public async Task<IRRFModel> PegarPorIdIrrf(int id)
    {
        try
        {
            var irrf = await _calculoImpostoContext.IRRF
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            if (irrf is not null)
            {
                return irrf;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<IEnumerable<IRRFModel>> PegarTodosIrrf(int pagina, int tamanho, string busca)
    {
        try
        {
            var irrfList = await _calculoImpostoContext.IRRF
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .OrderByDescending(w => w.Competencia)
                .ToListAsync();

            return irrfList;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<decimal> PorcentagemFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        var porcentagem = await _calculoImpostoContext.IRRF
             .Where(w => w.Faixa == faixa &&
                         w.Competencia == _calculoImpostoContext.IRRF
                                          .Where(w => w.Competencia <= competencia)
                                          .Max(m => m.Competencia))
             .MaxAsync(m => m.Porcentagem);

        return porcentagem;
    }
    public async Task<int> TotalIrrf()
    {
        var totalIrrf = await _calculoImpostoContext.IRRF
             .CountAsync();
        return totalIrrf;
    }
    public async Task<decimal> ValorFaixaCompetenciaIrrf(DateTime competencia, int faixa)
    {
        var valorFaixa = await _calculoImpostoContext.IRRF
            .Where(w => w.Faixa == faixa &&
                        w.Competencia == _calculoImpostoContext.IRRF
                                         .Where(w => w.Competencia <= competencia)
                                         .Max(m => m.Competencia))
            .MaxAsync(m => m.Valor);

        return valorFaixa;
    }
}
