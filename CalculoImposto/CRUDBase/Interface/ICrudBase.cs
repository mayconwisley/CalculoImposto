namespace CalculoImposto.API.CRUD.Interface;

public interface ICrudBase<T>
{
    Task<IEnumerable<T>> PegarTodos(int pagina, int tamanho);
    Task<T> PegarPorId(int id);
    Task<T> Criar(T entity);
    Task<T> Atualizar(T entity);
    Task<T> Deletar(int id);
}
