using MediatR;
using Supermarket.Commands.Categories;
using Supermarket.Core.Services.Categories;
using Supermarket.Mapping.Categories;

namespace Supermarket.Handlers.Categories
{
    internal class CreateCategoryHandler : IRequestHandler<CreateCategory>
    {
        private readonly ICategoriesService _categoriesService;

        public CreateCategoryHandler(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task Handle(CreateCategory command, CancellationToken token)
        {
            var category = CategoryMapper.GetCategoryFromCreateCommand(command);
            await _categoriesService.CreateAsync(category);
        }

    }
}
