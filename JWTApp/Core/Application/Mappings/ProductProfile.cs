using AutoMapper;
using JWTApp.Core.Application.DTOs;
using JWTApp.Core.Domain;

namespace JWTApp.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
