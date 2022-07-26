using AutoMapper;
using Doco.Domain.Entities;

namespace Doco.Api.Dto.Entities
{
    public class UserDto : User
    {
    }

    public class UserDtoMapProfile : Profile
    {
        public UserDtoMapProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
