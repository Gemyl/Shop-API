using MediatR;
using Supermarket.Core.Dtos.Categories;

namespace Supermarket.Queries.Categories
{
    public class GetAllCategories : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
