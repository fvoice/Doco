using AutoMapper;
using Doco.Domain.Entities;
using Doco.Domain.Enums;

namespace Doco.Api.Dto.Entities
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserCreateDtoMapProfile : Profile
    {
        public UserCreateDtoMapProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
