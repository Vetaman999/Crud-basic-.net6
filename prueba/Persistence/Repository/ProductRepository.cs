using Microsoft.EntityFrameworkCore;
using prueba.Domain.Models;
using prueba.Domain.Percistence.Context;
using prueba.Domain.Percistence.Repositories;

namespace prueba.Persistence.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) 
        {

        }

        public async Task AddAsync(Product _product)
        {
            await _context.Products.AddAsync(_product);
        }

        public async Task<Product> FindById(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> FindByName(string name)
        {
            IEnumerable<Product> products = await _context.Products
                           .Where(u => u.Name == name)
                           .ToListAsync();
            return products.Count() > 0 ? products.First() : null;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
