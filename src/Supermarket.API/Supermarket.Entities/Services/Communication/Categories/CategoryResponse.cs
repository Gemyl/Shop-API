namespace Supermarket.Core.Services.Communication.Categories
{
    public class CategoryResponse : BaseResponse
    {
        public CategoryResponse(bool success, string message) : base(success, message)
        { }

        public CategoryResponse(bool success) : this(success, string.Empty) { }
    }
}
