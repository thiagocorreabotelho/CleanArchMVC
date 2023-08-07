using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProducrRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _applicationDbContext.Add(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _applicationDbContext.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _applicationDbContext.Product.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _applicationDbContext.Product.Include(m => m.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _applicationDbContext.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _applicationDbContext.Update(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }
    }
}