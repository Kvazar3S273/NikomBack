using AutoMapper;
using Data.Nikom.Entities.Products;
using Nikom.Models;

namespace Nikom.Mapper
{
    public class SubCategoryMapProfile : Profile
    {
        public SubCategoryMapProfile()
        {
            CreateMap<SubCategory, SubCategoryViewModel>()
                .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.Id));
        }
    }
}
