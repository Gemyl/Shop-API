using Supermarket.Core.Entities;

namespace Supermarket.Core.Repositories.Products
{
    public interface IProductsRepository
    {
        Task<IList<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task<Product> FindByIdAsync(Guid id);
        void Update(Product product);
        void Delete(Product product);
    }
}
