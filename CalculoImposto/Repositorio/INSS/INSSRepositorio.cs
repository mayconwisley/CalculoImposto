using CalculoImposto.API.Banco;
using CalculoImposto.API.CRUD.Interface;
using CalculoImposto.API.Model.INSS;
using CalculoImposto.API.Repositorio.INSS.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.INSS;

public class InssRepositorio(CalculoImpostoContext calculoImpostoContext, ICrudBase<InssModel> crud) : IInssRepositorio
{
    private readonly CalculoImpostoContext _calculoImpostoContext = calculoImpostoContext;
    private readonly ICrudBase<InssModel> _crud = crud;

    public async Task<InssModel> AtualizarInss(InssModel inss)
    {
        try
        {
            if (inss is not null)
            {
                await _crud.Atualizar(inss);
                return inss;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<InssModel> CriarInss(InssModel inss)
    {
        try
        {
            if (inss is not null)
            {
                await _crud.Criar(inss);
                return inss;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<InssModel> DeletarInss(int id)
    {
        try
        {
            var inss = await PegarPorIdInss(id);
            if (inss is not null)
            {
                await _crud.Deletar(inss.Id);
                return inss;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
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

    public async Task<InssModel> PegarPorIdInss(int id)
    {
        try
        {
            return await _crud.PegarPorId(id);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<IEnumerable<InssModel>> PegarTodosInss(int pagina, int tamanho, string busca)
    {
        try
        {
            return await _crud.PegarTodos(pagina, tamanho, busca);
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


}
