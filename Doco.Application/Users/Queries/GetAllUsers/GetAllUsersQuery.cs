using System.Collections.Generic;
using Doco.Domain.Entities;
using MediatR;

namespace Doco.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IReadOnlyCollection<User>>
    {
    }
}
