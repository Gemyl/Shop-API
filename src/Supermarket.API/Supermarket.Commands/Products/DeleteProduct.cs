using MediatR;
using Supermarket.Core.Services.Communication.Products;

namespace Supermarket.Commands.Products
{
    public class DeleteProduct : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
    }
}
