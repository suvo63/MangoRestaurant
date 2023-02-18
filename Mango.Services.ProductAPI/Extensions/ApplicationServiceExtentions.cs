using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Interfaces;
using Mango.Services.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Extensions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options=>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            // services.AddScoped<IPhotoService,PhotoService>();
          
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            
            return services;
        }
    }
}