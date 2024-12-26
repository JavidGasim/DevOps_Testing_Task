using DevOps_Testing_Task.Data;
using DevOps_Testing_Task.Entities;
using DevOps_Testing_Task.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Testing_Task.Repositories.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<Product>? AddAsync(Product product)
        {
            if (product == null) return null;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product>? GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        }
        public async Task<Product>? UpdateAsync(Product product)
        {
            var pr = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (pr == null) return null;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
