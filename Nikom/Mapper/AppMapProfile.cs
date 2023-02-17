using AutoMapper;
using Data.Nikom.Entities.Identity;
using Nikom.Models;

namespace Nikom.Mapper
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<RegisterViewModel, AppUser>()
                .ForMember(x => x.Photo, opt => opt.Ignore());
        }
    }
}
