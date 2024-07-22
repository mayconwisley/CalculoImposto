namespace CalculoImposto.API.CRUD.Interface;

public interface ICrudBase<T>
{
    Task<IEnumerable<T>> PegarTodos(int pagina, int tamanho, string busca);
    Task<T> PegarPorId(int id);
    Task<T> Criar(T t);
    Task<T> Atualizar(T t);
    Task<T> Deletar(int id);
}
