using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Interfaces;

namespace Mango.Services.ProductAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        public DataContext _context { get; }
        public UnitOfWork(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public IProductRepository ProductRepository => new ProductRepository(_context,_mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}