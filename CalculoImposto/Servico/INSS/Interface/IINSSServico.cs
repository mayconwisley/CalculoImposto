using CalculoImposto.Modelo.DTO.INSS;

namespace CalculoImposto.API.Servico.INSS.Interface
{
    public interface IINSSServico
    {
        Task<IEnumerable<INSSDto>> PegarTodosInss(int pagina, int tamanho, string busca);
        Task<IEnumerable<INSSDto>> PegarTodosPorCompetenciaInss(DateTime competencia);

        Task<int> PegarFaixaInss(DateTime competencia, decimal baseInss);
        Task<int> UltimaFaixaCompetenciaInss(DateTime competencia);

        Task<decimal> PorcentagemFaixaCompetenciaInss(DateTime competencia, int faixa);
        Task<decimal> ValorFaixaCompetenciaInss(DateTime competencia, int faixa);
        Task<decimal> ValorTetoCompetenciaInss(DateTime competencia);

        Task<INSSDto> PegarPorIdInss(int id);
        Task CriarInss(INSSDto inss);
        Task AtualizarInss(INSSDto inss);
        Task DeletarInss(int id);

        Task<int> TotalInss(string busca);
    }
}
