using CalculoImposto.API.Banco;
using CalculoImposto.API.Model.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.IRRF;

public class SimplificadoRepositorio(CalculoImpostoContext calculoImpostoContext) : ISimplificadoRepositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext = calculoImpostoContext;

    public async Task<SimplificadoModel> AtualizarSimplificado(SimplificadoModel simplificado)
    {
        try
        {
            if (simplificado is not null)
            {
                _calculoImpostoContext.Simplificados.Entry(simplificado).State = EntityState.Modified;
                await _calculoImpostoContext.SaveChangesAsync();
                return simplificado;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<SimplificadoModel> CriarSimplificado(SimplificadoModel simplificado)
    {
        try
        {
            if (simplificado is not null)
            {
                _calculoImpostoContext.Simplificados.Add(simplificado);
                await _calculoImpostoContext.SaveChangesAsync();
                return simplificado;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<SimplificadoModel> DeletarSimplificado(int id)
    {
        try
        {
            var simplificado = await PegarPorIdSimplificado(id);
            if (simplificado is not null)
            {
                _calculoImpostoContext.Simplificados.Remove(simplificado);
                await _calculoImpostoContext.SaveChangesAsync();
                return simplificado;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<SimplificadoModel> PegarPorIdSimplificado(int id)
    {
        try
        {
            var simplificado = await _calculoImpostoContext.Simplificados
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
            if (simplificado is not null)
            {
                return simplificado;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<IEnumerable<SimplificadoModel>> PegarTodosSimplificado(int pagina, int tamanho, string busca)
    {
        try
        {
            var simplificadoList = await _calculoImpostoContext.Simplificados
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .OrderByDescending(w => w.Competencia)
                .ToListAsync();

            return simplificadoList;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<int> TotalSimplificado()
    {
        var totalSimplificado = await _calculoImpostoContext.Simplificados
             .CountAsync();
        return totalSimplificado;
    }

    public async Task<decimal> ValorSimplificadoCompetencia(DateTime competencia)
    {
        var valorSimplificado = await _calculoImpostoContext.Simplificados
            .Where(w => w.Competencia == competencia)
            .MaxAsync(m => m.Valor);
        return valorSimplificado;
    }
}
