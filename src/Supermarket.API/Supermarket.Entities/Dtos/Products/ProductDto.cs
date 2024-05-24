using Supermarket.Core.Enums;

namespace Supermarket.Core.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public Guid CategoryId { get; set; }
    }
}
