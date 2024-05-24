namespace Supermarket.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
