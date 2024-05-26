using MediatR;
using Supermarket.Commands.Categories;
using Supermarket.Core.Services.Categories;
using Supermarket.Core.Services.Communication.Categories;
using Supermarket.Mapping.Categories;

namespace Supermarket.Handlers.Categories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, CategoryResponse>
    {
        private readonly ICategoriesService _categoriesService;

        public UpdateCategoryHandler(ICategoriesService categoriesService) 
        { 
            _categoriesService = categoriesService;
        }

        public async Task<CategoryResponse> Handle(UpdateCategory command, CancellationToken token)
        {
            var category = CategoryMapper.GetCategoryFromUpdateCommand(command);
            var result = await _categoriesService.Update(category);
            return result;
        }
    }
}
