using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Entities;
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

        public ProductDto CreateUpdateProduct(ProductDto productDto)
        {
            var product= _mapper.Map<Product>(productDto);
            if (product.ProductId>0)
                _context.Products.Add(product);
            else
                _context.Products.Add(product);
            return productDto;
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
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