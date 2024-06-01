using MediatR;
using Supermarket.Core.Dtos.Products;

namespace Supermarket.Queries.Products
{
    public class GetAllProducts : IRequest<IEnumerable<ProductDto>>
    {
    }
}
