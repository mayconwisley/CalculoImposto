using CalculoImposto.Modelo.DTO.INSS;

namespace CalculoImposto.API.Servico.INSS.Interface;

public interface IInssServico
{
    Task<IEnumerable<InssDto>> PegarTodosInss(int pagina, int tamanho, string busca);
    Task<IEnumerable<InssDto>> PegarTodosPorCompetenciaInss(DateTime competencia);
    Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss);
    Task<int> UltimaFaixaCompetenciaInss(DateTime competencia);
    Task<decimal> PorcentagemFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorFaixaCompetenciaInss(DateTime competencia, int faixa);
    Task<decimal> ValorTetoCompetenciaInss(DateTime competencia);
    Task<decimal> DescontoInssProgressivo(DateTime competencia, decimal baseInss);
    Task<InssDto> PegarPorIdInss(int id);
    Task CriarInss(InssDto inss);
    Task AtualizarInss(InssDto inss);
    Task DeletarInss(int id);
    Task<int> TotalInss(string busca);
}
