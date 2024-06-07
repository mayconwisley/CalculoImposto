using CalculoImposto.API.Banco;
using CalculoImposto.API.Model.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.IRRF;

public class IrrfRepositorio(CalculoImpostoContext calculoImpostoContext) : IIrrfRepositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext = calculoImpostoContext;

    public async Task<IrrfModel> AtualizarIrrf(IrrfModel irrf)
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
    public async Task<IrrfModel> CriarIrrf(IrrfModel irrf)
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
    public async Task<IrrfModel> DeletarIrrf(int id)
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
    public async Task<int> PegarFaixaIrrf(DateTime competencia, decimal valorBrutoIrrf)
    {
        try
        {
            var faixa = await _calculoImpostoContext.IRRF
               .Where(w => w.Valor >= valorBrutoIrrf &&
                           w.Competencia == _calculoImpostoContext.IRRF
                                            .Where(w => w.Competencia <= competencia)
                                            .Max(m => m.Competencia))
               .MinAsync(m => m.Faixa);

            return faixa;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<IEnumerable<IrrfModel>> PegarPorCompetenciaIrrf(DateTime competencia)
    {
        try
        {
            var irrfList = await _calculoImpostoContext.IRRF
                .Where(w => w.Competencia == competencia)
                .ToListAsync();

            if (irrfList is not null)
            {
                return irrfList;
            }
            return [];
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<IrrfModel> PegarPorIdIrrf(int id)
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
    public async Task<IEnumerable<IrrfModel>> PegarTodosIrrf(int pagina, int tamanho, string busca)
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
