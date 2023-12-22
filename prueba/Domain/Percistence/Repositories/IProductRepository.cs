using prueba.Domain.Models;

namespace prueba.Domain.Percistence.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<Product> FindById(long id);
        Task<Product> FindByName(string name);
        Task AddAsync(Product product);
        void Update(Product product);
        void Remove(Product product);
    }
}
