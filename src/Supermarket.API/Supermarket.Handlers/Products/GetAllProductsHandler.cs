using MediatR;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Dtos.Products;
using Supermarket.Core.Services.Products;
using Supermarket.Mapping.Products;
using Supermarket.Queries.Products;

namespace Supermarket.Handlers.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, IEnumerable<ProductDto>>
    {
        private readonly IProductsService _productsService;

        public GetAllProductsHandler(IProductsService productsService) 
        {
            _productsService = productsService;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProducts query, CancellationToken cancellationToken)
        {
            var products = await _productsService.GetAllAsync();
            var productsDtos = products.Select(p => 
            {
                var pDto = ProductsMapper.GetProductDto(p);
                return pDto;
            });

            return productsDtos;
        }
    }
}
