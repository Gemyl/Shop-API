using Supermarket.Commands.Products;
using Supermarket.Core.Entities;
using AutoMapper;
using Supermarket.Core.Dtos.Products;
using Supermarket.Extensions;

namespace Supermarket.Mapping.Products
{
    public class ProductsMapper
    {
        public static ProductDto GetProductDto(Product product)
        {
            var config = new MapperConfiguration(configure =>
                configure.CreateMap<Product, ProductDto>()
                    .ForMember(
                        src => src.UnitOfMeasurement,
                        opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString())
                    )
            );

            var mapper = config.CreateMapper();
            return mapper.Map<Product, ProductDto>(product);
        }

        public static Product GetProductFromCreateCommand(CreateProduct command)
        {
            var config = new MapperConfiguration(configure =>
                configure.CreateMap<CreateProduct, Product>()
            );

            var mapper = config.CreateMapper();
            return mapper.Map<CreateProduct, Product>( command );
        }

        public static Product GetProductFromUpdateCommand(UpdateProduct command)
        {
            var config = new MapperConfiguration(configure =>
                configure.CreateMap<UpdateProduct, Product>()
            );

            var mapper = config.CreateMapper();
            return mapper.Map<UpdateProduct, Product>(command);
        }
    }
}
