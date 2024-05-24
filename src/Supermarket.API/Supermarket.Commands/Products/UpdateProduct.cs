using Supermarket.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Commands.Products
{
    public class UpdateProduct
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public short QuantityInPackage { get; set; }

        [Required]
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
