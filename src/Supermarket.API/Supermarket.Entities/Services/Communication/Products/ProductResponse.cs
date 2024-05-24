using Supermarket.Core.Entities;

namespace Supermarket.Core.Services.Communication.Products
{
    public class ProductResponse : BaseResponse
    {
        public Product Product { get; private set; }

        private ProductResponse(bool success, string message, Product product) : base(success, message) 
        { 
            Product = product;
        }

        public ProductResponse(Product product) : this(true, string.Empty, product) { }
        public ProductResponse(string message) : this(false, message, new Product()) { }
    }
}
