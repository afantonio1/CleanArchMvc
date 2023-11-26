using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories
{
   #nullable disable
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _context.Product.Include(p => p.Category).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
