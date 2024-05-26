using MediatR;
using Supermarket.Core.Dtos.Categories;
using Supermarket.Core.Services.Categories;
using Supermarket.Mapping.Categories;
using Supermarket.Queries.Categories;

namespace Supermarket.Handlers.Categories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategories, IEnumerable<CategoryDto>>
    {
        private readonly ICategoriesService _categoriesService;

        public GetCategoriesHandler(ICategoriesService categoriesService) 
        { 
            _categoriesService = categoriesService;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategories query, CancellationToken token) 
        {
            var categories = await _categoriesService.GetAllAsync();
            var categoriesDto = categories.Select(c =>
            {
                var cDto = CategoryMapper.GetCategoryDto(c);
                return cDto;
            });

            return categoriesDto;
        }
    }
}
