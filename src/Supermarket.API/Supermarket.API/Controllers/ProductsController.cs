using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Extensions;
using Supermarket.Commands.Products;
using MediatR;
using Supermarket.Queries.Products;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllCategories(GetAllProducts query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct command) 
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Success);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProduct command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Success);
        }
    }
}
