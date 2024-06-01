using Supermarket.Core.Entities;

namespace Supermarket.Core.Services.Communication.Products
{
    public class ProductResponse : BaseResponse
    {
        public ProductResponse(bool success, string message) : base(success, message) { }
        public ProductResponse(bool success) : this(success, string.Empty) { }
    }
}
