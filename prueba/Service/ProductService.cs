using prueba.Domain.Models;
using prueba.Domain.Percistence.Repositories;
using prueba.Domain.Services;
using prueba.Domain.Services.Comunications;
using prueba.Persistence.Repository;

namespace prueba.Service
{
    public class ProductService : IProductService
    {
    
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProductResponse> DeleteAsync(long id)
        {
            var existingProduct = await _productRepository.FindById(id);
            if (existingProduct == null) 
            {
                return new ProductResponse("Product not found");
            }
            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while deleting the product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> GetByIdAsync(long id)
        {
            var existingProduct = await _productRepository.FindById(id);

            if (existingProduct == null)
            {
                return new ProductResponse("Product not found");
            }
            return new ProductResponse(existingProduct);
        }

        public async Task<ProductResponse> GetByNameAsync(string name)
        {
            var existingProduct = await _productRepository.FindByName(name);

            if (existingProduct == null)
            {
                return new ProductResponse("Product not found");
            }
            return new ProductResponse(existingProduct);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<ProductResponse> SaveAsync(Product product)
        {
            var isProduct = await _productRepository.FindByName(product.Name);
            if (isProduct is not null)
            {
                return new ProductResponse("There already exists a product with the name: " + product.Name);
            }
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while saving the product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(long id, Product product)
        {
            var existingProduct = await _productRepository.FindById(id);
            if (existingProduct == null)
                return new ProductResponse("Product not found");

            if (existingProduct.Name == product.Name)
            {
                if (existingProduct.Description == product.Description)
                {
                    return new ProductResponse($"Your NEW Name is already in use");
                }
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.ExpirationDate = product.ExpirationDate;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while updating the product: {ex.Message}");
            }
        }
    }
}
