using E_commerce.Dtos.ProductDto;
using E_commerce.Services.Interface;
using E_commerce.Utiltiy;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet("getAllProduct")]
        public async Task<IActionResult> GetAllProduct() {
            try
            {
                var products = await productService.GetAllProductAsync();
                return Ok(new SuccessResponse<IEnumerable<ProductDto>>(products, "Product list retrieved successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }


        [HttpGet("getProductById/{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            try
            {
                var product = await productService.GetProductByIdAsync(id);
                if (product is null)
                    return NotFound(new ErrorResponse<string>("Product not found."));
                return Ok(new SuccessResponse<ProductDto>(product, "Product retrieved successfully."));
            }
            catch(Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }

        }

        [HttpPost("createProduct")]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto product)
        {
            try
            {
                var newProduct = await productService.CreateProductAsync(product);
                if (newProduct is null)
                    return BadRequest(new ErrorResponse<string>("Something went wrong."));
                return Ok(new SuccessResponse<ProductDto>(newProduct, "Product created successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<ProductDto>> DeleteProduct(int id)
        {
            var product = await productService.DeleteProductAsync(id);
            if (product is null)
                return NotFound(new ErrorResponse<string>("Product not found."));
            return Ok(new SuccessResponse<ProductDto> (product, "Product deleted successfully."));
        }

        [HttpPut("updateProduct/{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductDto product)
        {
            var updatedProduct = await productService.UpdateProductAsync(id, product);
            if (updatedProduct is null)
                return BadRequest(new ErrorResponse<string>("Product not found."));
            return Ok(new SuccessResponse<ProductDto> (updatedProduct, "Product updated successfull."));
        }
    }

}
