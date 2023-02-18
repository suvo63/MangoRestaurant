using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
           var product= await _context.Products.FindAsync(productId);
           return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _context.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}