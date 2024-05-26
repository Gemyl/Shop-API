using MediatR;
using Supermarket.Commands.Categories;
using Supermarket.Core.Services.Categories;
using Supermarket.Core.Services.Communication.Categories;
using Supermarket.Mapping.Categories;

namespace Supermarket.Handlers.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, CategoryResponse>
    {
        private readonly ICategoriesService _categoriesService;

        public CreateCategoryHandler(ICategoriesService categoriesService)
        { 
            _categoriesService = categoriesService;
        }

        public async Task<CategoryResponse> Handle(CreateCategory command, CancellationToken token)
        {
            var category = CategoryMapper.GetCategoryFromCreateCommand(command);
            var result = await _categoriesService.CreateAsync(category);
            return result;
        }

    }
}
