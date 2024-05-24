using Supermarket.Core.Entities;
using Supermarket.Core.Services.Communication.Categories;

namespace Supermarket.Core.Services.Categories
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<SaveCategoryResponse> CreateAsync(Category category);
        Task<SaveCategoryResponse> Update(Category category);
        Task<DeleteCategoryResponse> Delete(Guid id);
    }
}
