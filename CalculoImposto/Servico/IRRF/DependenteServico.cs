using CalculoImposto.API.MapeamentoDto.IrrfDto;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF;

public class DependenteServico(IDependenteRepositorio dependenteRepositorio) : IDependenteServico
{
    private readonly IDependenteRepositorio _dependenteRepositorio = dependenteRepositorio;

    public async Task AtualizarDependente(DependenteDto dependente)
    {
        await _dependenteRepositorio.AtualizarDependente(dependente.ConverterDtoParaDependente());
    }

    public async Task CriarDependente(DependenteDto dependente)
    {
        await _dependenteRepositorio.CriarDependente(dependente.ConverterDtoParaDependente());
    }

    public async Task DeletarDependente(int id)
    {
        var dependente = await _dependenteRepositorio.PegarPorIdDependente(id);
        if (dependente is not null)
        {
            await _dependenteRepositorio.DeletarDependente(dependente.Id);
        }
    }

    public async Task<DependenteDto> PegarPorCompetenciaDependente(DateTime competencia)
    {
        var dependente = await _dependenteRepositorio.PegarPorCompetenciaDependente(competencia);
        return dependente.ConverterDependenteParaDto();
    }

    public async Task<DependenteDto> PegarPorIdDependente(int id)
    {
        var dependente = await _dependenteRepositorio.PegarPorIdDependente(id);
        return dependente.ConverterDependenteParaDto();
    }

    public async Task<IEnumerable<DependenteDto>> PegarTodosDependente(int pagina, int tamanho, string busca)
    {
        var dependenteList = await _dependenteRepositorio.PegarTodosDependente(pagina, tamanho, busca);
        return dependenteList.ConverterDependentesParaDtos();
    }

    public async Task<int> TotalDependente()
    {
        var totalDependente = await _dependenteRepositorio.TotalDependente();
        return totalDependente;
    }

    public async Task<decimal> ValorDependenteCompetencia(DateTime competencia)
    {
        var valorDependente = await _dependenteRepositorio.ValorDependenteCompetencia(competencia);
        return valorDependente;
    }
}
