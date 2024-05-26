using Supermarket.Core.Entities;
using Supermarket.Core.Services.Communication.Categories;

namespace Supermarket.Core.Services.Categories
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<CategoryResponse> CreateAsync(Category category);
        Task<CategoryResponse> Update(Category category);
        Task<CategoryResponse> Delete(Guid id);
    }
}
