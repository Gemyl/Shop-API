using MediatR;
using Supermarket.Core.Services.Communication.Categories;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Commands.Categories
{
    public class DeleteCategory : IRequest<CategoryResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
