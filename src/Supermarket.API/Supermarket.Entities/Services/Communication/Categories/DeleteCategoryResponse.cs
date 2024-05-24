namespace Supermarket.Core.Services.Communication.Categories
{
    public class DeleteCategoryResponse : BaseResponse
    {
        private DeleteCategoryResponse(bool success, string message) : base(success, message) { }
        public DeleteCategoryResponse() : this(true, string.Empty) { }
        public DeleteCategoryResponse(string message) : this(false, message) { }
    }
}
