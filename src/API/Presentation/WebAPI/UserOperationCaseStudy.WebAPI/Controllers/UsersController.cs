using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserOperationCaseStudy.Application.Features.Users.Commands.CreateUser;
using UserOperationCaseStudy.Application.Features.Users.Commands.DeleteUser;
using UserOperationCaseStudy.Application.Features.Users.Commands.UpdateUser;
using UserOperationCaseStudy.Application.Features.Users.Queries.GetUserById;
using UserOperationCaseStudy.Application.Features.Users.Queries.GetUsers;

namespace UserOperationCaseStudy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            return Ok(await Mediator.Send(new DeleteUserRequest { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllUsersRequest();
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new GetUserRequest { Id = id }));
        }
    }
}
