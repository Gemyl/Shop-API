using MediatR;
using Supermarket.Core.Services.Communication.Products;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Commands.Products
{
    public class DeleteProduct : IRequest<ProductResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
