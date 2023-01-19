using AutoMapper;
using JWTApp.Core.Application.DTOs;
using JWTApp.Core.Domain;
using System.Diagnostics.Contracts;

namespace JWTApp.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
