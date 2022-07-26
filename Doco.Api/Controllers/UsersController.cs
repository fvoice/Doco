using AutoMapper;
using Doco.Api.Dto.Commands;
using Doco.Api.Dto.Entities;
using Doco.Application.Users.Commands.CreateUserCommand;
using Doco.Application.Users.Commands.UpdateUserCommand;
using Doco.Application.Users.Queries.GetAllUsers;
using Doco.Application.Users.Queries.GetUserById;
using Doco.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Doco.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(_mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<UserDto>>(users));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById([FromRoute]int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<User, UserDto>(user));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        public async Task<ActionResult> Create(CreateUserCommandDto request)
        {
            var id = await _mediator.Send(_mapper.Map<CreateUserCommand>(request));
            return Created($"user/{id}" , id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<ActionResult> Update(UpdateUserCommandDto request, [FromRoute]int id)
        {
            var domainRequest = _mapper.Map<UpdateUserCommand>(request);
            domainRequest.User.Id = id;
            await _mediator.Send(domainRequest);
            return Ok();
        }
    }
}