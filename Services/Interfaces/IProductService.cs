using BookSystemApi.Dto;
using BookSystemApi.Dto.Product;

namespace BookSystemApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductResponseNew>> GetProductByIdAsyncRaw(string id);
        Task AddProductAsync(ProductRequestDto productDto);
        Task UpdateProductAsync(int id, ProductRequestDto productDto);
        Task DeleteProductAsync(int id);
    }
}