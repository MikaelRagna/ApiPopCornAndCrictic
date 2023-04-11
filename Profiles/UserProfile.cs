using AutoMapper;
using PopCornAndCritics.Data.Dtos.UserDto;
using PopCornAndCritics.Model;

namespace PopCornAndCritics.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UpdateUserDto>();
        CreateMap<User, ReadUserDto>();
        CreateMap<User, LoginUserDto>();
    }
}
