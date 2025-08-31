using BookSystemApi.Dto;
using BookSystemApi.Entities;
using BookSystemApi.Repositories.Interfaces;
using BookSystemApi.Services.Interfaces;

namespace BookSystemApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }

        public async Task<ProductResponseDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task AddProductAsync(ProductRequestDto product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price
            };

            await _productRepository.AddProductAsync(newProduct);
        }

        // Updates an existing product with new data
        public async Task UpdateProductAsync(int id, ProductRequestDto productDto)
        {
            var product = await _productRepository.GetProductByIdAsync(id); // Fetch the product by ID

            // If the product does not exist, throw an exception
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            // Update product fields with new values from DTO
            product.Name = productDto.Name;
            product.Price = productDto.Price;

            // Save the updated product in the database
            await _productRepository.UpdateProductAsync(product);
        }

        // Deletes a product by ID
        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id); // Fetch the product by ID

            // If the product does not exist, throw an exception
            if (product == null)
                throw new KeyNotFoundException("Product not found");

            // Delete the product from the database
            await _productRepository.DeleteProductAsync(id);
        }
    }
}