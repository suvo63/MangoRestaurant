using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Entities;

namespace Mango.Services.ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
        ProductDto CreateUpdateProduct(ProductDto productDto);
        void DeleteProduct(Product product);
    }
}