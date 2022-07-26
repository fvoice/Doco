using System.Collections.Generic;
using Doco.Domain.Entities;
using MediatR;

namespace Doco.Api.Dto.Queries
{
    public class GetAllUsersQueryDto : IRequest<IReadOnlyCollection<User>>
    {
    }
}
