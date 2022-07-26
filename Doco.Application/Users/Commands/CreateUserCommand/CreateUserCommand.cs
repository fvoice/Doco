using Doco.Domain.Entities;
using MediatR;

namespace Doco.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<int>
    {
        public User User { get; set; }
    }
}