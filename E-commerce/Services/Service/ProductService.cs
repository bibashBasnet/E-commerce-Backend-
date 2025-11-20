using E_commerce.Context;
using E_commerce.Dtos.ProductDto;
using E_commerce.Models;
using E_commerce.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace E_commerce.Services.Service
{
    public class ProductService(ECommerceContext _context): IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var products = await _context.products.ToListAsync();
            return products.Select(u => new ProductDto
            {
                ProductId = u.ProductId,
                ProductName = u.ProductName,
                ProductQuantity = u.ProductQuantity,
                ProductPrice = u.ProductPrice,
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _context.products
                .Where(u => u.ProductId == id)
                .Select(u => new ProductDto { 
                    ProductId = u.ProductId,
                    ProductName = u.ProductName,
                    ProductQuantity = u.ProductQuantity,
                    ProductPrice = u.ProductPrice
                }).FirstOrDefaultAsync();
            return product;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto product)
        {
            ProductModel newProduct = new ProductModel
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity
            };
            await _context.products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            ProductDto createdProduct = new ProductDto
            {
                ProductId = newProduct.ProductId,
                ProductName = newProduct.ProductName,
                ProductQuantity = newProduct.ProductQuantity,
                ProductPrice = newProduct.ProductPrice,
            };
            return createdProduct;
        }

        public async Task<ProductDto?> DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if(product is null)
                return null;
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            ProductDto deletedProduct = new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity
            };
            return deletedProduct;
        }

        public async Task<ProductDto?> UpdateProductAsync(int id, ProductDto product)
        {
            var productDetail = await _context.products.FindAsync(id);
            if (productDetail is null)
                return null;
            productDetail.ProductName = product.ProductName;
            productDetail.ProductPrice = product.ProductPrice;
            productDetail.ProductQuantity = product.ProductQuantity;
            await _context.SaveChangesAsync();
            ProductDto updatedProduct = new ProductDto
            {
                ProductId = productDetail.ProductId,
                ProductName = productDetail.ProductName,
                ProductPrice = productDetail.ProductPrice,
                ProductQuantity = productDetail.ProductQuantity
            };
            return updatedProduct;
        }
    }
}
