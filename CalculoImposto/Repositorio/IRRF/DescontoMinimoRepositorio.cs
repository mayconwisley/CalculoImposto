using CalculoImposto.API.Banco;
using CalculoImposto.API.Model.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CalculoImposto.API.Repositorio.IRRF;

public class DescontoMinimoRepositorio(CalculoImpostoContext calculoImpostoContext) : IDescontoMinimoRespositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext = calculoImpostoContext;

    public async Task<DescontoMinimoModel> AtualizarDescontoMinimo(DescontoMinimoModel descontoMinimo)
    {
        try
        {
            if (descontoMinimo is not null)
            {
                _calculoImpostoContext.DescontoMinimos.Entry(descontoMinimo).State = EntityState.Modified;
                await _calculoImpostoContext.SaveChangesAsync();
                return descontoMinimo;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<DescontoMinimoModel> CriarDescontoMinimo(DescontoMinimoModel descontoMinimo)
    {
        try
        {
            if (descontoMinimo is not null)
            {
                _calculoImpostoContext.DescontoMinimos.Add(descontoMinimo);
                await _calculoImpostoContext.SaveChangesAsync();
                return descontoMinimo;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<DescontoMinimoModel> DeletarDescontoMinimo(int id)
    {
        try
        {
            var descontoMinimo = await PegarPorIdDescontoMinimo(id);
            if (descontoMinimo is not null)
            {
                _calculoImpostoContext.DescontoMinimos.Remove(descontoMinimo);
                await _calculoImpostoContext.SaveChangesAsync();
                return descontoMinimo;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<DescontoMinimoModel> PegarPorCompetenciaDescontoMinimo(DateTime competencia)
    {
        try
        {
            var descontoMinimo = await _calculoImpostoContext.DescontoMinimos
                .Where(w => w.Competencia == competencia)
                .FirstOrDefaultAsync();

            if (descontoMinimo is not null)
            {
                return descontoMinimo;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<DescontoMinimoModel> PegarPorIdDescontoMinimo(int id)
    {
        try
        {
            var descontoMinimo = await _calculoImpostoContext.DescontoMinimos
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            if (descontoMinimo is not null)
            {
                return descontoMinimo;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<IEnumerable<DescontoMinimoModel>> PegarTodosDescontoMinimo(int pagina, int tamanho, string busca)
    {
        try
        {
            var descontoMinimoList = await _calculoImpostoContext.DescontoMinimos
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .OrderByDescending(w => w.Competencia)
                .ToListAsync();

            return descontoMinimoList;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<int> TotalDescontoMinimo()
    {
        var totalDescontoMinimo = await _calculoImpostoContext.DescontoMinimos
             .CountAsync();
        return totalDescontoMinimo;
    }

    public async Task<decimal> ValorDescontoMinimoCompetencia(DateTime competencia)
    {
        var valorDescontoMinimo = await _calculoImpostoContext.DescontoMinimos
            .Where(w => w.Competencia == competencia)
            .MaxAsync(m => m.Valor);
        return valorDescontoMinimo;
    }
}
