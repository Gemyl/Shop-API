
using MediatR;
using Supermarket.Commands.Products;
using Supermarket.Core.Services.Communication.Products;
using Supermarket.Core.Services.Products;
using Supermarket.Mapping.Products;

namespace Supermarket.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, ProductResponse>
    {
        private readonly IProductsService _productsService;
    
        public UpdateProductHandler(IProductsService productsService) 
        { 
            _productsService = productsService;
        }

        public async Task<ProductResponse> Handle(UpdateProduct command, CancellationToken cancellationToken)
        {
            var product = ProductsMapper.GetProductFromUpdateCommand(command);
            var result = await _productsService.Update(product);

            return result;
        }
    }
}
