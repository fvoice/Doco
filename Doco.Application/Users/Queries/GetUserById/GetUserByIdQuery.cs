using Doco.Domain.Entities;
using MediatR;

namespace Doco.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User?>
    {
        public int Id { get; set; }
    }
}
