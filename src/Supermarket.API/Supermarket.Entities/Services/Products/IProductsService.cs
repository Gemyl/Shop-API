using Supermarket.Core.Entities;
using Supermarket.Core.Services.Communication.Products;

namespace Supermarket.Core.Services.Products
{
    public interface IProductsService
    {
        Task<IList<Product>> GetAllAsync();
        Task<ProductResponse> CreateAsync(Product product);
        Task<ProductResponse> Update(Product product);
        Task<ProductResponse> Delete(Guid Id);
    }
}
