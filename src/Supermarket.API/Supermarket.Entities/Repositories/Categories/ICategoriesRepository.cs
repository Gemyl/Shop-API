using Supermarket.Core.Entities;

namespace Supermarket.Core.Repositories.Categories
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task<Category> FindByIdAsync(Guid id);
        void Update(Category category);
        void Delete(Category category);
    }
}
