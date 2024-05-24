using Microsoft.AspNetCore.Mvc;
using Supermarket.Commands.Categories;
using Supermarket.Core.Dtos;
using Supermarket.Core.Services.Categories;
using Supermarket.Mapping.Categories;
using Supermarket.API.Extensions;
using Supermarket.Queries.Categories;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoryService;

        public CategoriesController(ICategoriesService categoryService) 
        { 
            _categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        { 
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = categories.Select(c => 
            {
                var cDto = CategoryMapper.GetCategoryDto(c);
                return cDto;
            });

            return categoriesDto;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategory command) 
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = CategoryMapper.GetCategoryFromCreateCommand(command);
            var result = await _categoryService.CreateAsync(category);

            if (!result.Success) 
            {
                return BadRequest(result.Message);
            }

            var categoryDto = CategoryMapper.GetCategoryDto(result.Category);
            return Ok(categoryDto);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategory command)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = CategoryMapper.GetCategoryFromUpdateCommand(command);
            var result = await _categoryService.Update(category);

            if (!result.Success)
            { 
                return BadRequest(result.Message);
            }

            var categoryDto = CategoryMapper.GetCategoryDto(result.Category);
            return Ok(categoryDto);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategory query)
        {
            var result = await _categoryService.Delete(query.Id);

            if (!result.Success)
            { 
                return BadRequest(result.Message); 
            }

            return Ok(result.Success);
        }

    }
}
