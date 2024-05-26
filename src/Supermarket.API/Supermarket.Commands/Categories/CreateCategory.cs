using MediatR;
using Supermarket.Core.Dtos;
using Supermarket.Core.Services.Communication.Categories;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Commands.Categories
{
    public class CreateCategory: IRequest<CategoryResponse>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
