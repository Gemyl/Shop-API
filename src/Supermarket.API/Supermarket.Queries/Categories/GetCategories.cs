using MediatR;
using Supermarket.Core.Dtos.Categories;

namespace Supermarket.Queries.Categories
{
    public class GetCategories : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
