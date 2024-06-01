using MediatR;
using Supermarket.Commands.Products;
using Supermarket.Core.Services.Communication.Products;
using Supermarket.Core.Services.Products;
using Supermarket.Mapping.Products;

namespace Supermarket.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, ProductResponse>
    {
        private readonly IProductsService _productsService;
        public CreateProductHandler(IProductsService productsService) 
        { 
            _productsService = productsService;
        }
        public async Task<ProductResponse> Handle(CreateProduct command, CancellationToken cancellationToken)
        {
            var product = ProductsMapper.GetProductFromCreateCommand(command);
            var result = await _productsService.CreateAsync(product);
            return result;
        }
    }
}
