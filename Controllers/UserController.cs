using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUDApp.Commands;
using SimpleCRUDApp.Models;
using SimpleCRUDApp.Models.Input;
using SimpleCRUDApp.Queries;
using SimpleCRUDApp.Repositories;

namespace SimpleCRUDApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IUserRepository userRepository, IMediator mediator)
        {
            _mediator = mediator;
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult<int>> CreateUser(
            [FromBody] CreateUserInput input)
        {
            CreateUserCommand command = new(input.Name, input.Phone, input.Email);

            int result = await _mediator.Send(command);

            return Ok(result);
        }

        // READ
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsersList()
        {
            GetUsersListQuery query = new();

            List<User> result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<User>> GetUserById(
            [FromRoute] int userId)
        {
            GetUserByIdQuery query = new(userId);

            User result = await _mediator.Send(query);

            return Ok(result);
        }

        // UPDATE
        [HttpPut]
        [Route("{userId}")]
        public async Task<ActionResult<bool>> UpdateUser(
            [FromRoute] int userId,
            [FromBody] UpdateUserInput input)
        {
            UpdateUserCommand command = new(userId,input.Name,input.Phone,input.Email);

            bool result = await _mediator.Send(command);

            return Ok(result);
        }

        // DELETE
        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<bool>> DeleteUser(
            [FromRoute] int userId)
        {
            DeleteUserCommand command = new(userId);

            bool result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
