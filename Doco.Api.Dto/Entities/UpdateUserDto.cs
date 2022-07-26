using AutoMapper;
using Doco.Domain.Entities;
using Doco.Domain.Enums;

namespace Doco.Api.Dto.Entities
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UpdateUserDtoMapProfile : Profile
    {
        public UpdateUserDtoMapProfile()
        {
            CreateMap<UpdateUserDto, User>();
        }
    }
}
