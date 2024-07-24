using CalculoImposto.API.MapeamentoDto.IRRF;
using CalculoImposto.API.Repositorio.IRRF.Interface;
using CalculoImposto.API.Servico.IRRF.Interface;
using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF;

public class DependenteServico(IDependenteRepositorio dependenteRepositorio) : IDependenteServico
{
    private readonly IDependenteRepositorio _dependenteRepositorio = dependenteRepositorio;

    public async Task<DependenteDto> Atualizar(DependenteDto dependente)
    {
        var dependenteDto = await _dependenteRepositorio.Atualizar(dependente.ConverterDtoParaDependente());
        return dependenteDto.ConverterDependenteParaDto();
    }

    public async Task<DependenteDto> Criar(DependenteDto dependente)
    {
        var dependenteDto = await _dependenteRepositorio.Criar(dependente.ConverterDtoParaDependente());
        return dependenteDto.ConverterDependenteParaDto();

    }

    public async Task<DependenteDto> Deletar(int id)
    {
        var dependente = await _dependenteRepositorio.PegarPorId(id);
        if (dependente is not null)
        {
            var dependenteDto = await _dependenteRepositorio.Deletar(dependente.Id);
            return dependenteDto.ConverterDependenteParaDto();
        }
        return new();
    }

    public async Task<DependenteDto> PegarPorCompetenciaDependente(DateTime competencia)
    {
        var dependente = await _dependenteRepositorio.PegarPorCompetenciaDependente(competencia);
        return dependente.ConverterDependenteParaDto();
    }

    public async Task<DependenteDto> PegarPorId(int id)
    {
        var dependente = await _dependenteRepositorio.PegarPorId(id);
        return dependente.ConverterDependenteParaDto();
    }

    public async Task<IEnumerable<DependenteDto>> PegarTodos(int pagina, int tamanho)
    {
        var dependenteList = await _dependenteRepositorio.PegarTodos(pagina, tamanho);
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
