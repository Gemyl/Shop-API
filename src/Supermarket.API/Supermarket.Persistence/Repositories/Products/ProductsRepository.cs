using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Products;
using Supermarket.Persistence.Contexts;

namespace Supermarket.Persistence.Repositories.Products
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository(SupermarketContext context) : base(context) { }

        public async Task<IList<Product>> GetAllAsync() 
        { 
            return await _context.Products.ToListAsync();
        }

        public async Task AddAsync(Product product) 
        { 
            await _context.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(Guid Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public void Update(Product product)
        { 
            _context.Products.Update(product);
        }

        public void Delete(Product product) 
        {
            _context.Products.Remove(product);
        }

    }
}
