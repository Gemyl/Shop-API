using AutoMapper;
using Supermarket.Core.Dtos.Categories;
using Supermarket.Core.Entities;
using Supermarket.Commands.Categories;

namespace Supermarket.Mapping.Categories
{
    public class CategoryMapper
    {
        public static CategoryDto GetCategoryDto(Category category) 
        {
            var config = new MapperConfiguration(configure =>
                configure.CreateMap<Category, CategoryDto>()
            );

            var mapper = config.CreateMapper();
            return mapper.Map<Category, CategoryDto>(category);
        }

        public static Category GetCategoryFromCreateCommand(CreateCategory command) 
        {
            var config = new MapperConfiguration(configure => 
            {
                configure.CreateMap<CreateCategory, Category>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<CreateCategory, Category>(command);
        }

        public static Category GetCategoryFromUpdateCommand(UpdateCategory command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<UpdateCategory, Category>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<UpdateCategory, Category>(command);
        }
    }
}
