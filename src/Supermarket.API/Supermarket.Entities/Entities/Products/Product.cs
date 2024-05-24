using Supermarket.Core.Enums;

namespace Supermarket.Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
