using CalculoImposto.API.Banco;
using CalculoImposto.API.CRUD;
using CalculoImposto.API.Model.INSS;
using CalculoImposto.API.Repositorio.INSS.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.INSS;

public class InssRepositorio : CrudBase<InssModel>, IInssRepositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext;

    public InssRepositorio(CalculoImpostoContext calculoImpostoContext) : base(calculoImpostoContext)
    {
        _calculoImpostoContext = calculoImpostoContext;
    }

    public async Task<IEnumerable<InssModel>> PegarTodosPorCompetenciaInss(DateTime competencia)
    {
        try
        {
            var inssList = await _calculoImpostoContext.INSS
                .Where(w => w.Competencia == competencia)
                .ToListAsync();

            if (inssList is not null)
            {
                return inssList;
            }
            return [];
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<int> TotalInss(string busca)
    {
        if (string.IsNullOrEmpty(busca))
        {
            busca = DateTime.Now.ToString();
        }


        var totalInss = await _calculoImpostoContext.INSS
            .Where(w => w.Competencia == DateTime.Parse(busca))
            .CountAsync();
        return totalInss;
    }
    public async Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss)
    {
        try
        {
            var faixaInss = await _calculoImpostoContext.INSS
                                    .Where(w => w.Valor >= baseInss &&
                                            w.Competencia == _calculoImpostoContext.INSS
                                                            .Where(w => w.Competencia <= competencia)
                                                            .Max(m => m.Competencia))
                                     .MinAsync(m => m.Faixa);
            return faixaInss;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<int> UltimaFaixaCompetenciaInss(DateTime competencia)
    {
        try
        {
            var faixaInss = await _calculoImpostoContext.INSS
                                    .Where(w => w.Competencia == competencia)
                                    .MaxAsync(m => m.Faixa);
            return faixaInss;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<decimal> PorcentagemFaixaCompetenciaInss(DateTime competencia, int faixa)
    {
        try
        {
            var porcentagemInss = await _calculoImpostoContext.INSS
                                    .Where(w => w.Faixa == faixa &&
                                           w.Competencia == _calculoImpostoContext.INSS
                                                            .Where(w => w.Competencia <= competencia)
                                                            .Max(m => m.Competencia))
                                    .Select(s => s.Porcentagem)
                                    .FirstOrDefaultAsync();
            return porcentagemInss;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<decimal> ValorFaixaCompetenciaInss(DateTime competencia, int faixa)
    {
        try
        {
            var valorFaixaInss = await _calculoImpostoContext.INSS
                                    .Where(w => w.Faixa == faixa &&
                                           w.Competencia == _calculoImpostoContext.INSS
                                                            .Where(w => w.Competencia <= competencia)
                                                            .Max(m => m.Competencia))
                                    .Select(s => s.Valor)
                                    .FirstOrDefaultAsync();
            return valorFaixaInss;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<decimal> ValorTetoCompetenciaInss(DateTime competencia)
    {
        try
        {
            var valorTetoInss = await _calculoImpostoContext.INSS
                                    .Where(w => w.Competencia == _calculoImpostoContext.INSS
                                                            .Where(w => w.Competencia <= competencia)
                                                            .Max(m => m.Competencia))
                                    .MaxAsync(s => s.Valor);
            return valorTetoInss;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public new async Task<IEnumerable<InssModel>> PegarTodos(int pagina, int tamanho)
    {
        try
        {
            var inssList = await _calculoImpostoContext.INSS
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .OrderByDescending(w => w.Competencia)
                .ToListAsync();

            return inssList;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public new async Task<InssModel> PegarPorId(int id)
    {
        try
        {
            var inss = await _calculoImpostoContext.INSS
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            if (inss is not null)
            {
                return inss;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public new async Task<InssModel> Criar(InssModel entity)
    {
        try
        {
            if (entity is not null)
            {
                _calculoImpostoContext.INSS.Add(entity);
                await _calculoImpostoContext.SaveChangesAsync();
                return entity;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public new async Task<InssModel> Atualizar(InssModel entity)
    {
        try
        {
            if (entity is not null)
            {
                _calculoImpostoContext.INSS.Entry(entity).State = EntityState.Modified;
                await _calculoImpostoContext.SaveChangesAsync();
                return entity;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public new async Task<InssModel> Deletar(int id)
    {
        try
        {
            var inss = await PegarPorId(id);
            if (inss is not null)
            {
                _calculoImpostoContext.INSS.Remove(inss);
                await _calculoImpostoContext.SaveChangesAsync();
                return inss;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
