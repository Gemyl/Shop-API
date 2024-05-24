using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Extensions;
using Supermarket.Commands.Products;
using Supermarket.Core.Services.Products;
using Supermarket.Mapping.Products;
using Supermarket.Queries;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService) 
        { 
            _productsService = productsService;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllCategories()
        {
            var allProducts = await _productsService.GetAllAsync();
            var allProductsDtos = allProducts.Select(p => 
            {
                var pDto = ProductsMapper.GetProductDto(p);
                return pDto;
            });

            return Ok(allProductsDtos);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProduct command) 
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = ProductsMapper.GetProductFromCreateCommand(command);
            var result = await _productsService.CreateAsync(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productDto = ProductsMapper.GetProductDto(result.Product);
            return Ok(productDto);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProduct command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = ProductsMapper.GetProductFromUpdateCommand(command);
            var result = await _productsService.Update(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productDto = ProductsMapper.GetProductDto(result.Product);
            return Ok(productDto);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProduct query)
        {
            var result = await _productsService.Delete(query.Id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Success);
        }
    }
}
