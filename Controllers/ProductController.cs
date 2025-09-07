using BookSystemApi.Dto;
using BookSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // Handles HTTP GET request to fetch a single product by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsyncRaw(id); // Calls service to fetch product by ID
                return Ok(product); // Returns 200 OK response if found
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if product does not exist
            }
        }

        // Handles HTTP POST request to add a new product
        [HttpPost]
        public  IActionResult Add([FromBody] ProductRequestDto productDto)
        {
            Console.WriteLine($"POST {System.Text.Json.JsonSerializer.Serialize(productDto)}");
            if (productDto == null)
            {
                return BadRequest("The productDto field is required.");
            }
            var result = _productService.AddProductAsync(productDto); // Calls service to add a new product

            return Ok(new { RowsAffected = result });
            // return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto); 
            // Returns 201 Created response with location header pointing to the new product
        }

        // Handles HTTP PUT request to update an existing product
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductRequestDto productDto)
        {
            try
            {
                await _productService.UpdateProductAsync(id, productDto); // Calls service to update product
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if product does not exist
            }
        }

        // Handles HTTP DELETE request to delete a product by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id); // Calls service to delete product
                return NoContent(); // Returns 204 No Content response on success
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Returns 404 Not Found if product does not exist
            }
        }


    }

}