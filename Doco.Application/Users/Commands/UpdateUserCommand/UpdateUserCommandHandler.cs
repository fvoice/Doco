using System;
using System.Threading;
using System.Threading.Tasks;
using Doco.Application.Interfaces.Repositories;
using Doco.Application.Interfaces.Services;
using MediatR;

namespace Doco.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserTypeService _userTypeService;

        public UpdateUserCommandHandler(IUserRepository repository, IUserTypeService userTypeService)
        {
            _repository = repository;
            _userTypeService = userTypeService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetById(request.User.Id);

            if (existing == null)
            {
                throw new Exception($"A user with Id - {request.User.Id} is not found");
            }

            existing.LastModified = DateTime.Now;
            existing.Name = request.User.Name;
            existing.Email = request.User.Email;
            existing.Type = await _userTypeService.CalculateUserType(request.User);

            await _repository.Update(existing);

            return Unit.Value;
        }
    }
}