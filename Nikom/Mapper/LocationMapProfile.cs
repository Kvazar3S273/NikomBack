using AutoMapper;
using Data.Nikom.Entities.Products;
using Nikom.Models;

namespace Nikom.Mapper
{
    public class LocationMapProfile : Profile
    {
        public LocationMapProfile()
        {
            CreateMap<Location, LocationViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Box, opt => opt.MapFrom(dest => dest.Box));
        }
    }
}
