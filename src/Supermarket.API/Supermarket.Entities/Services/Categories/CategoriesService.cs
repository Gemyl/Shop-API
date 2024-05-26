using Supermarket.Core.Entities;
using Supermarket.Core.Repositories;
using Supermarket.Core.Repositories.Categories;
using Supermarket.Core.Services.Communication.Categories;

namespace Supermarket.Core.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesService(ICategoriesRepository categoryRepository,IUnitOfWork unitOfWork) 
        { 
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();    
        }

        public async Task<CategoryResponse> CreateAsync(Category category)
        {
            try 
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(true, category.Id.ToString());
            }
            catch (Exception ex) 
            {
                return new CategoryResponse(false, ex.Message);
            }
        }

        public async Task<CategoryResponse> Update(Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(category.Id);

            if (existingCategory == null)
            { 
                return new CategoryResponse(false, "Category Not Found");
            }

            existingCategory.Name = category.Name;

            try 
            {     
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(true);
            }
            catch (Exception ex)
            {
                return new CategoryResponse(false, ex.Message);
            }
        }

        public async Task<CategoryResponse> Delete(Guid id)
        {
            try 
            {
                var category = await _categoryRepository.FindByIdAsync(id);

                if (category == null) 
                {
                    return new CategoryResponse(false, "Category Not Found");
                }

                _categoryRepository.Delete(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(true);
            }
            catch (Exception ex)
            {
                return new CategoryResponse(false, ex.Message);
            }
        }
    }
}
