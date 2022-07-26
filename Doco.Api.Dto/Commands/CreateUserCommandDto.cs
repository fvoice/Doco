using AutoMapper;
using Doco.Api.Dto.Entities;
using Doco.Application.Users.Commands.CreateUserCommand;

namespace Doco.Api.Dto.Commands
{
    public class CreateUserCommandDto
    {
        public CreateUserDto User { get; set; }
    }

    public class CreateUserCommandDtoMapProfile : Profile
    {
        public CreateUserCommandDtoMapProfile()
        {
            CreateMap<CreateUserCommandDto, CreateUserCommand>();
        }
    }
}
