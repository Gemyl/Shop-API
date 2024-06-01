using Supermarket.Core.Entities;
using Supermarket.Core.Repositories;
using Supermarket.Core.Repositories.Products;
using Supermarket.Core.Services.Communication.Products;

namespace Supermarket.Core.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsService(IProductsRepository productsRepository, IUnitOfWork unitOfWork) 
        { 
            _productsRepository = productsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Product>> GetAllAsync()
        { 
            return await _productsRepository.GetAllAsync();
        }

        public async Task<ProductResponse> CreateAsync(Product product) 
        {
            try 
            {
                await _productsRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(true, product.Id.ToString());
            }
            catch (Exception ex) 
            { 
                return new ProductResponse(false, ex.Message);
            }
        }

        public async Task<ProductResponse> Update(Product product)
        {
            try 
            {
                var existingProduct = await _productsRepository.FindByIdAsync(product.Id);

                if (existingProduct == null) 
                {
                    return new ProductResponse(false, "Product Not Found");
                }

                existingProduct.Name = product.Name;
                existingProduct.QuantityInPackage = product.QuantityInPackage;
                existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
                existingProduct.CategoryId = product.CategoryId;

                _productsRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(true);
            }
            catch (Exception ex) 
            {
                return new ProductResponse(false, ex.Message);
            }
        }

        public async Task<ProductResponse> Delete(Guid id)
        {
            try 
            {
                var product = await _productsRepository.FindByIdAsync(id);

                if (product == null) 
                {
                    return new ProductResponse(false, "Product Not Found");
                }

                _productsRepository.Delete(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(true);
            }
            catch (Exception ex) 
            {
                return new ProductResponse(false, ex.Message);
            }
        }
    }
}
