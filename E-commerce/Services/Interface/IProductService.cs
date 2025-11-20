using E_commerce.Dtos.ProductDto;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace E_commerce.Services.Interface
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAllProductAsync();
        public Task<ProductDto?> GetProductByIdAsync(int id);
        public Task<ProductDto> CreateProductAsync(ProductDto product);
        public Task<ProductDto?> DeleteProductAsync(int id);
        public Task<ProductDto?> UpdateProductAsync(int id, ProductDto product);
    }
}
