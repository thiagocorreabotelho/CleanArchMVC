using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Category> Create(Category category)
        {
            _applicationDbContext.Add(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _applicationDbContext.Category.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _applicationDbContext.Category.FindAsync(id);
        }

        public async Task<Category> Remove(Category category)
        {
            _applicationDbContext.Remove(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _applicationDbContext.Update(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }
    }
}