using AutoMapper;
using Data.Nikom.Entities.Products;
using Nikom.Models;
namespace Nikom.Mapper
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.Id));
        }
    }
}
