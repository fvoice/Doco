using Doco.Domain.Entities;
using MediatR;

namespace Doco.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest
    {
        public User User { get; set; }
    }
}