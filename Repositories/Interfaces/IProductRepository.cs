using BookSystemApi.Dto;
using BookSystemApi.Dto.Product;
using BookSystemApi.Entities;

namespace BookSystemApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task<int> AddProductAsyncRaw(Product product);
        Task<IEnumerable<ProductResponseNew>> GetProductByIdAsyncRaw(string id);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}