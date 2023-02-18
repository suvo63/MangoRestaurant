using Mango.Services.ProductAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
