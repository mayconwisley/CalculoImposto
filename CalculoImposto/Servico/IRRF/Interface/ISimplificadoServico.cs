using CalculoImposto.Modelo.DTO.IRRF;

namespace CalculoImposto.API.Servico.IRRF.Interface;

public interface ISimplificadoServico
{
    Task<IEnumerable<SimplificadoDto>> PegarTodosSimplificado(int pagina, int tamanho, string busca);
    Task<SimplificadoDto> PegarPorCompetenciaSimplificado(DateTime competencia);
    Task<SimplificadoDto> PegarPorIdSimplificado(int id);
    Task CriarSimplificado(SimplificadoDto simplificado);
    Task AtualizarSimplificado(SimplificadoDto simplificado);
    Task DeletarSimplificado(int id);
    Task<int> TotalSimplificado();
    Task<decimal> ValorSimplificadoCompetencia(DateTime competencia);
}
