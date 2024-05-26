using MediatR;
using Supermarket.Core.Services.Communication.Categories;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Commands.Categories
{
    public class UpdateCategory : IRequest<CategoryResponse>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
