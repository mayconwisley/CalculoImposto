namespace CalculoImposto.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsynk();
}
