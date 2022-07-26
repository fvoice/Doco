using AutoMapper;
using Doco.Domain.Entities;

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
            CreateMap<UpdateUserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Type, o => o.Ignore())
                .ForMember(x => x.Created, o => o.Ignore())
                .ForMember(x => x.LastModified, o => o.Ignore());
        }
    }
}
