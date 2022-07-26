using System;
using System.Threading;
using System.Threading.Tasks;
using Doco.Application.Interfaces.Repositories;
using Doco.Application.Interfaces.Services;
using MediatR;

namespace Doco.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;
        private readonly IUserTypeService _userTypeService;

        public CreateUserCommandHandler(IUserRepository repository, IUserTypeService userTypeService)
        {
            _repository = repository;
            _userTypeService = userTypeService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.Created = DateTime.Now;
            request.User.LastModified = DateTime.Now;
            request.User.Type = await _userTypeService.CalculateUserType(request.User);

            return await _repository.Create(request.User);
        }
    }
}