using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Dtos;

namespace Mango.Services.ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);

        Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(int productId);
    }
}