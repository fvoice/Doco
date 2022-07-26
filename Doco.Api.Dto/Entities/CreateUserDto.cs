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
            CreateMap<CreateUserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Type, o => o.Ignore())
                .ForMember(x => x.Created, o => o.Ignore())
                .ForMember(x => x.LastModified, o => o.Ignore());
        }
    }
}
