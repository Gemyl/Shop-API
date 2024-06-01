using Microsoft.AspNetCore.Mvc;
using Supermarket.Commands.Categories;
using Supermarket.Core.Dtos.Categories;
using Supermarket.API.Extensions;
using Supermarket.Queries.Categories;
using MediatR;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCategories")]
        public async Task<IEnumerable<CategoryDto>> GetCategories(GetAllCategories query)
        {
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategory command) 
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _mediator.Send(command);
            return Ok(result.Message);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategory command)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState.GetErrorMessages());
            }
            
            var result = await _mediator.Send(command);
            if (!result.Success) 
            { 
                return Ok(result.Message);
            }

            return Ok(result.Success);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategory command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success) 
            {
                return Ok(result.Message);
            }

            return Ok(result.Success);
        }

    }
}
