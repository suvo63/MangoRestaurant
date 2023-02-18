using AutoMapper;
using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Entities;

namespace Mango.Services.ProductAPI.Controllers.Helpers
{
    public class AutoMapperProfiles : Profile
    {
       public AutoMapperProfiles()
       {
            CreateMap<ProductDto,Product>().ReverseMap();
       }
    }
}