using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Doco.Application.Interfaces.Repositories;
using Doco.Domain.Entities;
using MediatR;

namespace Doco.Application.Users.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyCollection<User>>
    {
        private readonly IUserRepository _repository;

        public GetAllUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyCollection<User?>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}