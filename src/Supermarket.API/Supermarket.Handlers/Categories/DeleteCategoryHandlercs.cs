using MediatR;
using Supermarket.Core.Services.Categories;
using Supermarket.Core.Services.Communication.Categories;
using Supermarket.Commands.Categories;

namespace Supermarket.Handlers.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, CategoryResponse>
    {
        private readonly ICategoriesService _categoriesService;

        public DeleteCategoryHandler(ICategoriesService categoriesService) 
        { 
            _categoriesService = categoriesService;
        }

        public async Task<CategoryResponse> Handle(DeleteCategory command, CancellationToken token)
        {
            var result = await _categoriesService.Delete(command.Id);
            return result;
        }
    }
}
