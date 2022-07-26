using AutoMapper;
using Doco.Api.Dto.Entities;
using Doco.Application.Users.Commands.UpdateUserCommand;

namespace Doco.Api.Dto.Commands
{
    public class UpdateUserCommandDto
    {
        public UpdateUserDto User { get; set; }
    }

    public class UpdateUserCommandDtoMapProfile : Profile
    {
        public UpdateUserCommandDtoMapProfile()
        {
            CreateMap<UpdateUserCommandDto, UpdateUserCommand>();
        }
    }
}
