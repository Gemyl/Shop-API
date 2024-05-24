using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Categories;
using Supermarket.Persistence.Contexts;

namespace Supermarket.Persistence.Repositories.Categories
{
    public class CategoriesRepository : BaseRepository, ICategoriesRepository
    {
        public CategoriesRepository(SupermarketContext context) : base(context) 
        { 
        }

        public async Task<IEnumerable<Category>> GetAllAsync() 
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category) 
        { 
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
