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

        public async Task<SaveCategoryResponse> CreateAsync(Category category)
        {
            try 
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch (Exception ex) 
            {
                return new SaveCategoryResponse(ex.Message);
            }
        }

        public async Task<SaveCategoryResponse> Update(Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(category.Id);

            if (existingCategory == null)
            { 
                return new SaveCategoryResponse("Category Not Found");
            }

            existingCategory.Name = category.Name;

            try 
            {     
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new SaveCategoryResponse(ex.Message);
            }
        }

        public async Task<DeleteCategoryResponse> Delete(Guid id)
        {
            try 
            {
                var category = await _categoryRepository.FindByIdAsync(id);

                if (category == null) 
                {
                    return new DeleteCategoryResponse("Category Not Found");
                }

                _categoryRepository.Delete(category);
                await _unitOfWork.CompleteAsync();
                return new DeleteCategoryResponse();
            }
            catch (Exception ex)
            {
                return new DeleteCategoryResponse(ex.Message);
            }
        }
    }
}
