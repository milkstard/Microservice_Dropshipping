using AccountsService.DTO;
using AccountsService.Models;
using AutoMapper;

namespace AccountsService.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserLoginDTO>().ReverseMap();
            CreateMap<Users, UserRegisterDTO>().ForMember(dest => dest.UserType, curr => curr.MapFrom(src => src.UserTypeFK));
            //CreateMap<UserRegisterDTO, Users>().ForMember(dest
            //CreateMap<UserRegisterDTO, Users>()
            //.ForMember(dest => dest.UserTypeFK, opt => opt.MapFrom(src => src.UserType))
            //.ForMember(dest => dest.Created_date, opt => opt.MapFrom(_ => DateTime.UtcNow))
            //.ForMember(dest => dest.Updated_date, opt => opt.MapFrom(_ => DateTime.UtcNow))
            //.ForMember(dest => dest.UserSaltId, opt => opt.Ignore())
            //.ForMember(dest => dest.UserType, opt => opt.Ignore())
            //.ForMember(dest => dest.UserSalt, opt => opt.Ignore());
        }
    }
}
