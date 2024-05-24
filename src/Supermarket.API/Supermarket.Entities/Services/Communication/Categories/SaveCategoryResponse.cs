using Supermarket.Core.Entities;

namespace Supermarket.Core.Services.Communication.Categories
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        public SaveCategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        public SaveCategoryResponse(string message) : this(false, message, new Category())
        { }
    }
}
