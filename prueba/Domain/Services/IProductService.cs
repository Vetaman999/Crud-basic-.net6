using prueba.Domain.Models;
using prueba.Domain.Services.Comunications;

namespace prueba.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> GetByIdAsync(long id);
        Task<ProductResponse> GetByNameAsync(string name);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(long id, Product product);
        Task<ProductResponse> DeleteAsync(long id);
    }
}
