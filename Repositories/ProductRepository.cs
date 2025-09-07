using System.Drawing;
using BookSystemApi.Data;
using BookSystemApi.Dto;
using BookSystemApi.Dto.Product;
using BookSystemApi.Entities;
using BookSystemApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSystemApi.Repositories
{
    public class ProductRepository : IProductRepository
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

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        // public async Task AddProductAsyncRaw(Product product)
        // {
        //     var rows = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Products (Name, Price) VALUES ({0}, {1})", product.Name, product.Price);
        //     Console.WriteLine($"Rows affected: {rows}");

        // }

        public async Task<int> AddProductAsyncRaw(Product product)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "INSERT INTO \"Products\" (\"Name\", \"Price\") VALUES ({0}, {1})",
                product.Name, product.Price
            );

        }

        public async Task<IEnumerable<ProductResponseNew>> GetProductByIdAsyncRaw(string id)
        {
            return await _context.Set<ProductResponseNew>().FromSqlRaw(
                "SELECT \"Name\", \"Price\" FROM \"Products\" WHERE \"Id\" = {0}",
                id
            ).ToListAsync();
        }
        

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        
        // Deletes a product by its ID
        public async Task DeleteProductAsync(int id)
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