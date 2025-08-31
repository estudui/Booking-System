using System.Drawing;
using BookSystemApi.Data;
using BookSystemApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSystemApi.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implement repository methods here
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        
        // Deletes a product by its ID
        public async Task DeleteAsync(int id)
        {
            // Finds the product in the database using the provided ID
            var product = await _context.Products.FindAsync(id);

            // If the product exists, remove it from the database
            if (product != null)
            {
                _context.Products.Remove(product);

                // Saves the changes to the database asynchronously
                await _context.SaveChangesAsync();
            }
        }
    }
}