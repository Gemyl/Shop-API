using MediatR;
using Supermarket.Commands.Products;
using Supermarket.Core.Services.Communication.Products;
using Supermarket.Core.Services.Products;

namespace Supermarket.Handlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, ProductResponse>
    {
        private readonly IProductsService _productsService;
        public DeleteProductHandler(IProductsService productsService) 
        { 
            _productsService = productsService;
        }

        public async Task<ProductResponse> Handle(DeleteProduct command, CancellationToken cancellationToken)
        {
            var result = await _productsService.Delete(command.Id);
            return result;
        }
    }
}
